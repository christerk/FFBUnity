using Fumbbl;
using Fumbbl.Ffb.Dto;
using Fumbbl.Lib;
using Fumbbl.Model;
using Fumbbl.Model.Types;
using Fumbbl.View;
using System.Linq;
using UnityEngine;

public class FieldHandler : MonoBehaviour
{
    public Camera MainCamera;
    public GameObject AbstractIconPrefab;
    public GameObject ArrowPrefab;
    public GameObject BallPrefab;
    public GameObject DugoutAway;
    public GameObject DugoutHome;
    public GameObject Field;
    public GameObject PlayerCardAway;
    public GameObject PlayerCardHome;
    public GameObject PlayerIconPrefab;
    public GameObject ScrollTextPrefab;
    public GameObject SquareOverlay;
    public GameObject TrackNumberPrefab;
    public TMPro.TextMeshProUGUI AwayTeamText;
    public TMPro.TextMeshProUGUI HomeTeamText;

    private GameObject Ball;
    private Player HoverPlayer;
    private RectTransform FieldRect;
    private ViewObjectList<Player> Players;
    private ViewObjectList<PushbackSquare> PushbackSquares;
    private ViewObjectList<TrackNumber> TrackNumbers;

    #region MonoBehaviour Methods

    // Start is called before the first frame update
    private void Start()
    {
        FFB.Instance.OnReport += AddReport;

        FieldRect = Field.GetComponent<RectTransform>();

        foreach (var o in GameObject.FindGameObjectsWithTag("Clone"))
        {
            Destroy(o);
        }

        Ball = Instantiate(BallPrefab);
        Ball.transform.SetParent(Field.transform);

        Players = new PlayersView(this);

        PushbackSquares = new ViewObjectList<PushbackSquare>(s =>
        {
            GameObject obj = Instantiate(ArrowPrefab);
            var animator = obj.GetComponent<Animator>();
            animator.SetTrigger(s.Direction);
            return obj;
        },
        s =>
        {
            if (s != null && s.ModelObject.Coordinate != null && s.GameObject != null)
            {
                s.GameObject.transform.SetParent(Field.transform);
                s.GameObject.transform.localPosition = FieldToWorldCoordinates(s.ModelObject.Coordinate.X, s.ModelObject.Coordinate.Y, 10);
            }
        },
        s =>
        {
            var animator = s.GameObject.GetComponent<Animator>();
            animator.SetTrigger("FadeOut");
        });

        TrackNumbers = new ViewObjectList<TrackNumber>(t =>
        {
            GameObject obj = Instantiate(TrackNumberPrefab);
            t.LabelObject = obj.GetComponentInChildren<TMPro.TextMeshPro>();
            return obj;
        },
        t =>
        {
            if (t != null && t.ModelObject.Coordinate != null && t.GameObject != null)
            {
                t.GameObject.transform.SetParent(Field.transform);
                t.GameObject.transform.localPosition = FieldToWorldCoordinates(t.ModelObject.Coordinate.X, t.ModelObject.Coordinate.Y, 10);
                t.ModelObject.LabelObject.SetText(t.ModelObject.Number.ToString());
            }
        },
        t =>
        {
            Destroy(t.GameObject);
        });

        var players = FFB.Instance.Model.GetPlayers();
        Players.Refresh(players);

        if (FFB.Instance.Model.TeamHome != null)
        {
            HomeTeamText.text = FFB.Instance.Model.TeamHome.Name.ToUpper();
        }
        if (FFB.Instance.Model.TeamAway != null)
        {
            AwayTeamText.text = FFB.Instance.Model.TeamAway.Name.ToUpper();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        Players.Refresh(FFB.Instance.Model.GetPlayers());
        PushbackSquares.Refresh(FFB.Instance.Model.PushbackSquares.Values);
        TrackNumbers.Refresh(FFB.Instance.Model.TrackNumbers.Values);

        var ball = FFB.Instance.Model.Ball;
        if (ball != null && ball.Coordinate != null)
        {
            bool isInPlayerHands = !ball.Moving && FFB.Instance.Model.GetPlayer(ball.Coordinate) != null;
            Ball.SetActive(true);

            Ball.transform.localScale = Vector3.one * (isInPlayerHands ? 0.5f : 1f);

            float translate = isInPlayerHands ? 36f : 0f;

            var ballPos = FieldToWorldCoordinates(ball.Coordinate.X, ball.Coordinate.Y, 4);
            ballPos.x += translate;
            ballPos.y -= translate;
            Ball.transform.localPosition = ballPos;

            var ballRenderer = Ball.GetComponentInChildren<SpriteRenderer>();
            Color c = ballRenderer.color;
            c.a = ball.InPlay ? 1f : 0.7f;
            ballRenderer.color = c;
        }
        else
        {
            Ball.SetActive(false);
        }

        var actingPlayer = FFB.Instance.Model.GetPlayer(FFB.Instance.Model.ActingPlayer.PlayerId);
        if (actingPlayer != null)
        {
            if (actingPlayer.IsHome)
            {
                PlayerCardHome.GetComponent<PlayerCardHandler>().SetPlayer(actingPlayer);
                PlayerCardAway.GetComponent<PlayerCardHandler>().SetPlayer(HoverPlayer);
            }
            else
            {
                PlayerCardHome.GetComponent<PlayerCardHandler>().SetPlayer(HoverPlayer);
                PlayerCardAway.GetComponent<PlayerCardHandler>().SetPlayer(actingPlayer);
            }
        } else
        {
            PlayerCardHome.GetComponent<PlayerCardHandler>().SetPlayer(HoverPlayer != null && HoverPlayer.IsHome ? HoverPlayer : null);
            PlayerCardAway.GetComponent<PlayerCardHandler>().SetPlayer(HoverPlayer != null && !HoverPlayer.IsHome ? HoverPlayer : null);
        }
    }

    private void OnDestroy()
    {
        FFB.Instance.OnReport -= AddReport;
    }

    private void OnMouseEnter()
    {
        SquareOverlay.SetActive(true);
    }

    private void OnMouseExit()
    {
        SquareOverlay.SetActive(false);
    }

    private void OnMouseOver()
    {
        var point = MainCamera.ScreenToWorldPoint(Input.mousePosition) - Field.transform.localPosition;
        var x = (int)(point.x - FieldRect.offsetMin.x + FieldRect.anchoredPosition.x) / 144;
        var y = (int)(FieldRect.sizeDelta.y - (point.y - FieldRect.offsetMin.y + FieldRect.anchoredPosition.y)) / 144;
        // x,y is the zero-based field square coordinate.
        var coord = new Coordinate(x, y);

        Highlight(coord);
    }

    #endregion

    internal Vector3 FieldToWorldCoordinates(float x, float y, float z)
    {
        x = x * 144 - 13 * 144 + 72;
        y = 2160 / 2 - 72 - y * 144;

        return new Vector3(x, y, z);
    }

    internal Vector3 ToDugoutCoordinates(int index)
    {
        int x = index % 5;
        int y = index / 5;

        return new Vector3(x * 144 - 280, 160 - y * 144, 0);
    }

    private void AddReport(Report report)
    {
        if (report is Fumbbl.Ffb.Dto.Reports.PlayerAction r)
        {
            var action = r.playerAction.As<Fumbbl.Model.Types.PlayerAction>();
            if (action.ShowActivity && FFB.Instance.ReportMode != FFB.ReportModeType.Silent)
            {
                Player player = FFB.Instance.Model.GetPlayer(r.actingPlayerId);
                var scrollText = Instantiate(ScrollTextPrefab);
                scrollText.gameObject.transform.SetParent(Field.transform);
                var text = scrollText.GetComponentInChildren<TMPro.TextMeshPro>();
                text.text = action.ShortDescription;
                Vector3 coords = FieldToWorldCoordinates(player.Coordinate.X, player.Coordinate.Y, 5);
                coords.y += 100;
                scrollText.gameObject.transform.localPosition = coords;
                scrollText.GetComponent<Animator>().SetTrigger("Scroll");
            }
        }
    }

    private void Highlight(Coordinate coord)
    {
        SquareOverlay.transform.localPosition = FieldToWorldCoordinates(coord.X, coord.Y, 1);
        HoverPlayer = FFB.Instance.Model.GetPlayer(coord);
    }
}
