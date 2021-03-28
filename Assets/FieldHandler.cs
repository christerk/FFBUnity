using Fumbbl;
using Fumbbl.Ffb.Dto;
using Fumbbl.Lib;
using Fumbbl.Model;
using Fumbbl.Model.Types;
using Fumbbl.View;
using System;
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
    public GameObject SelectionMarker;
    public TMPro.TextMeshPro AwayTeamText;
    public TMPro.TextMeshPro HomeTeamText;

    private GameObject Ball;
    private Player HoverPlayer;
    private RectTransform FieldRect;
    private ViewObjectList<Player> Players;
    private ViewObjectList<Fumbbl.Model.Types.PushbackSquare> PushbackSquares;
    private ViewObjectList<Fumbbl.Model.Types.TrackNumber> TrackNumbers;

    public GameObject FieldPlayers;
    public GameObject HomePlayers;
    public GameObject AwayPlayers;

    public float IconHoverDistance = 20f;

    public Player homeCardPlayer { get; private set; } = null;
    public Player awayCardPlayer { get; private set; } = null;



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
        Ball.transform.SetParent(FieldPlayers.transform);

        Players = new PlayersView(this);

        PushbackSquares = new ViewObjectList<Fumbbl.Model.Types.PushbackSquare>(s =>
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
                s.GameObject.transform.SetParent(FieldPlayers.transform);
                s.GameObject.transform.localPosition = FieldToWorldCoordinates(s.ModelObject.Coordinate.X, s.ModelObject.Coordinate.Y, 1f);
            }
        },
        s =>
        {
            var animator = s.GameObject.GetComponent<Animator>();
            animator.SetTrigger("FadeOut");
        });

        TrackNumbers = new ViewObjectList<Fumbbl.Model.Types.TrackNumber>(t =>
        {
            GameObject obj = Instantiate(TrackNumberPrefab);
            return obj;
        },
        t =>
        {
            if (t != null && t.ModelObject.Coordinate != null && t.GameObject != null)
            {
                t.GameObject.transform.SetParent(FieldPlayers.transform);
                t.GameObject.transform.localPosition = FieldToWorldCoordinates(t.ModelObject.Coordinate.X, t.ModelObject.Coordinate.Y, 0.1f);
                var labelObject = t.GameObject.GetComponentInChildren<TMPro.TextMeshPro>();
                labelObject.SetText(t.ModelObject.Number.ToString());
            }
        },
        t =>
        {
            Destroy(t.GameObject);
        });

        var players = FFB.Instance.Model.Players;
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
        Players.Refresh(FFB.Instance.Model.Players);
        PushbackSquares.Refresh(FFB.Instance.Model.PushbackSquares);
        TrackNumbers.Refresh(FFB.Instance.Model.TrackNumbers);

        var ball = FFB.Instance.Model.Ball;
        if (ball != null && ball.Coordinate != null)
        {
            bool isInPlayerHands = !ball.Moving && FFB.Instance.Model.GetPlayer(ball.Coordinate) != null;
            Ball.SetActive(true);

            Ball.transform.localScale = Vector3.one * (isInPlayerHands ? 0.5f : 1f);

            float translate = isInPlayerHands ? 36f : 0f;

            var ballPos = FieldToWorldCoordinates(ball.Coordinate.X, ball.Coordinate.Y, 3f);
            ballPos.x += translate;
            ballPos.y -= translate;
            Ball.transform.localPosition = ballPos;

            //var ballRenderer = Ball.GetComponentInChildren<SpriteRenderer>();
            //Color c = ballRenderer.color;
            //c.a = ball.InPlay ? 1f : 0.7f;
            //ballRenderer.color = c;
        }
        else
        {
            Ball.SetActive(false);
        }

        var actingPlayer = FFB.Instance.Model.GetPlayer(FFB.Instance.Model.ActingPlayer.PlayerId);
        var defender = FFB.Instance.Model.GetPlayer(FFB.Instance.Model.DefenderId);

        if (actingPlayer != null)
        {
            if (actingPlayer.IsHome)
            {
                homeCardPlayer = actingPlayer;
                awayCardPlayer = HoverPlayer ?? defender;
            }
            else
            {
                homeCardPlayer = HoverPlayer ?? defender;
                awayCardPlayer = actingPlayer;
            }
        } else
        {
            homeCardPlayer = HoverPlayer != null && HoverPlayer.IsHome ? HoverPlayer : null;
            awayCardPlayer = HoverPlayer != null && !HoverPlayer.IsHome ? HoverPlayer : null;
        }

        PlayerCardHome.GetComponent<PlayerCardHandler>().SetPlayer(homeCardPlayer);
        PlayerCardAway.GetComponent<PlayerCardHandler>().SetPlayer(awayCardPlayer);
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
        var ray = MainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        Physics.Raycast(ray, out hitInfo);
        var worldPoint = hitInfo.point;

        var highlightPosition = SquareOverlay.transform.position;
        highlightPosition.x = (float) Math.Floor(worldPoint.x / 10f) * 10f + 5f;
        highlightPosition.z = (float) Math.Floor((worldPoint.z+5) / 10f) * 10f;

        SquareOverlay.transform.position = highlightPosition;

        //Highlight(coord);
    }

    #endregion

    internal Vector3 FieldToWorldCoordinates(float x, float y, float z)
    {
        var minX = -13f;
        var maxX = 13f;

        var minY = -7.5f;
        var maxY = 7.5f;


        var squareX = (maxX - minX) / 26f;
        var squareY = (maxY - minY) / 15f;

        x = x * 10 - 125;
        y = y * 10 - 70;

        return new Vector3(x, z, -y);
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
}
