using Fumbbl;
using Fumbbl.Ffb.Dto;
using Fumbbl.Ffb.Dto.Reports;
using Fumbbl.Lib;
using Fumbbl.Model;
using Fumbbl.Model.Types;
using Fumbbl.View;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class FieldHandler : MonoBehaviour
{
    public GameObject PlayerIconPrefab;
    public GameObject AbstractIconPrefab;
    public GameObject Field;
    public GameObject DugoutHome;
    public GameObject DugoutAway;
    public GameObject BallPrefab;
    public GameObject ArrowPrefab;
    public GameObject TrackNumberPrefab;
    public GameObject ScrollTextPrefab;

    public TMPro.TextMeshProUGUI HomeTeamText;
    public TMPro.TextMeshProUGUI AwayTeamText;

    private GameObject Ball;
    private ViewObjectList<Player> Players;
    private ViewObjectList<PushbackSquare> PushbackSquares;
    private ViewObjectList<TrackNumber> TrackNumbers;

    // Start is called before the first frame update
    void Start()
    {
        FFB.Instance.OnReport += AddReport;

        foreach (var o in GameObject.FindGameObjectsWithTag("Clone"))
        {
            Destroy(o);
        }

        Ball = Instantiate(BallPrefab);
        Ball.transform.SetParent(Field.transform);

        Players = new ViewObjectList<Player>(p =>
        {
            //GameObject obj = PlayerIcon.GenerateAbstractIcon(p);
            GameObject obj = PlayerIcon.GeneratePlayerIcon(p, PlayerIconPrefab);
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
                Vector3 coords = FieldToWorldCoordinates(player.Coordinate[0], player.Coordinate[1], 5);
                coords.y += 100;
                scrollText.gameObject.transform.localPosition = coords;
                scrollText.GetComponent<Animator>().SetTrigger("Scroll");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (FFB.Instance.Model.TeamHome != null)
        {
            HomeTeamText.text = FFB.Instance.Model.TeamHome.Name.ToUpper();
        }
        if (FFB.Instance.Model.TeamAway != null)
        {
            AwayTeamText.text = FFB.Instance.Model.TeamAway.Name.ToUpper();
        }

        var players = FFB.Instance.Model.GetPlayers().ToList();
        foreach (var p in players)
        {
            if (p.Coordinate != null && p.GameObject != null)
            {
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

                    p.GameObject.transform.localPosition = ToDugoutCoordinates(p.Coordinate[1]);
                }
                else
                {
                    var pos = FieldToWorldCoordinates(p.Coordinate[0], p.Coordinate[1], 1);

                    p.GameObject.transform.localPosition = pos;
                    p.GameObject.transform.SetParent(Field.transform);
                }
                p.GameObject?.SetActive(true);
            }
            else
            {
                p.GameObject?.SetActive(false);
            }
        }

        var ball = FFB.Instance.Model.Ball;
        if (ball != null && ball.Coordinate != null)
        {
            Ball.SetActive(true);
            var ballPos = FieldToWorldCoordinates(ball.Coordinate[0], ball.Coordinate[1], 4);
            Ball.transform.localPosition = ballPos;
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
                s.GameObject.transform.localPosition = FieldToWorldCoordinates(s.Coordinate[0], s.Coordinate[1], 10);
            }
        }

        var trackNumbers = FFB.Instance.Model.TrackNumbers.Values.ToList();
        TrackNumbers.Refresh(trackNumbers);
        foreach (var s in trackNumbers)
        {
            if (s != null && s.Coordinate != null && s.GameObject != null)
            {
                s.GameObject.transform.SetParent(Field.transform);
                s.GameObject.transform.localPosition = FieldToWorldCoordinates(s.Coordinate[0], s.Coordinate[1], 10);
                s.LabelObject.SetText(s.Number.ToString());
            }
        }
    }

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

    void OnDestroy()
    {
        FFB.Instance.Stop();
        FFB.Instance.OnReport -= AddReport;
    }
}
