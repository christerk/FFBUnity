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

        Players = new ViewObjectList<Player>(p =>
        {
            GameObject obj;

            if (FFB.Instance.Settings.Graphics.AbstractIcons)
            {
                obj = PlayerIcon.GeneratePlayerIconAbstract(p, AbstractIconPrefab);
            }
            else
            {
                obj = PlayerIcon.GeneratePlayerIcon(p, PlayerIconPrefab, AbstractIconPrefab);
            }
            obj.transform.SetParent(Field.transform);
            p.GameObject = obj;
        },
        p =>
        {
            Destroy(p.GameObject);
        });

        PushbackSquares = new ViewObjectList<PushbackSquare>(s =>
        {
            s.GameObject = Instantiate(ArrowPrefab);
            var animator = s.GameObject.GetComponent<Animator>();
            animator.SetTrigger(s.Direction);
        },
        s =>
        {
            var animator = s.GameObject.GetComponent<Animator>();
            animator.SetTrigger("FadeOut");
        });

        TrackNumbers = new ViewObjectList<TrackNumber>(t =>
        {
            t.GameObject = Instantiate(TrackNumberPrefab);
            t.LabelObject = t.GameObject.GetComponentInChildren<TMPro.TextMeshPro>();
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
        var ball = FFB.Instance.Model.Ball;
	//TODO: converting player dictionary to list is less than optimal!
        var players = FFB.Instance.Model.GetPlayers().ToList();

        bool ballOnPlayer = false;
        foreach (var p in players)
        {
            bool active = false;
            if (p.Coordinate != null && p.GameObject != null)
            {
                ballOnPlayer |= p.Coordinate.Equals(ball.Coordinate);
                var state = p.PlayerState;
                int moveToDugout = -1;
                if (state.IsReserve || state.IsExhausted || state.IsMissing)
                {
                    // Reserves box
                    moveToDugout = 0;
                }
                else if (state.IsKnockedOut)
                {
                    // KO Box
                    moveToDugout = 1;
                }
                else if (state.IsBadlyHurt || state.IsSeriousInjury || state.IsRip || state.IsBanned)
                {
                    // Cas Box
                    moveToDugout = 2;
                }

                if (moveToDugout >= 0)
                {
                    GameObject dugout = p.IsHome ? DugoutHome : DugoutAway;

                    Transform box = dugout.transform.GetChild(moveToDugout);
                    int index = box.childCount;
                    p.GameObject.transform.SetParent(box);

                    p.GameObject.transform.localPosition = ToDugoutCoordinates(p.Coordinate.Y);
                }
                else
                {
                    var pos = FieldToWorldCoordinates(p.Coordinate.X, p.Coordinate.Y, 1);

                    p.GameObject.transform.localPosition = pos;
                    p.GameObject.transform.SetParent(Field.transform);
                }
                active = true;
            }

            if (p.GameObject != null)
            {
                p.GameObject.SetActive(active);
            }
        }

        if (ball != null && ball.Coordinate != null)
        {
            bool isInPlayerHands = !ball.Moving && ballOnPlayer;
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

        var pushbackSquares = FFB.Instance.Model.PushbackSquares.Values.ToList();
        PushbackSquares.Refresh(pushbackSquares);

        foreach (var s in pushbackSquares)
        {
            if (s != null && s.Coordinate != null && s.GameObject != null)
            {
                s.GameObject.transform.SetParent(Field.transform);
                s.GameObject.transform.localPosition = FieldToWorldCoordinates(s.Coordinate.X, s.Coordinate.Y, 10);
            }
        }

        var trackNumbers = FFB.Instance.Model.TrackNumbers.Values.ToList();
        TrackNumbers.Refresh(trackNumbers);
        foreach (var s in trackNumbers)
        {
            if (s != null && s.Coordinate != null && s.GameObject != null)
            {
                s.GameObject.transform.SetParent(Field.transform);
                s.GameObject.transform.localPosition = FieldToWorldCoordinates(s.Coordinate.X, s.Coordinate.Y, 10);
                s.LabelObject.SetText(s.Number.ToString());
            }
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

        Highlight(x, y);
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
            if (action.ShowActivity)
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

    private void Highlight(int x, int y)
    {
        SquareOverlay.transform.localPosition = FieldToWorldCoordinates(x, y, 1);
        HoverPlayer = FFB.Instance.Model.GetPlayer(x, y);
    }
}
