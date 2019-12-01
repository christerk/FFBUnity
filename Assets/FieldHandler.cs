using Fumbbl;
using Fumbbl.View;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FieldHandler : MonoBehaviour
{
    public GameObject PlayerIconPrefab;
    public GameObject Field;
    public GameObject DugoutHome;
    public GameObject DugoutAway;
    public GameObject BallPrefab;
    public GameObject ArrowPrefab;
    public GameObject TrackNumberPrefab;

    private static Color HomeColour = new Color(0.66f, 0.19f, 0.19f);
    private static Color AwayColour = new Color(0f, 0f, 1f);

    private Dictionary<string, GameObject> Players;
    private GameObject Ball;
    private ViewObjectList<PushbackSquare> PushbackSquares;
    private ViewObjectList<TrackNumber> TrackNumbers;

    // Start is called before the first frame update
    void Start()
    {
        Players = new Dictionary<string, GameObject>();
        Ball = Instantiate(BallPrefab);
        Ball.transform.SetParent(Field.transform);
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
            t.LabelObject = t.GameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>();
        },
        t =>
        {
            Destroy(t.GameObject);
        });
    }

    // Update is called once per frame
    void Update()
    {
        var players = FFB.Instance.Model.GetPlayers();

        foreach (var p in players)
        {
            if (!Players.ContainsKey(p.Id))
            {
                GameObject obj = Instantiate(PlayerIconPrefab);
                var handler = obj.GetComponent<PlayerHandler>();
                obj.transform.SetParent(Field.transform);
                handler.Player = p;
                obj.name = p.Id;

                var child = obj.transform.GetChild(0).gameObject;
                Renderer s = child.GetComponent<Renderer>();
                s.material.color = p.IsHome ? HomeColour : AwayColour;

                TMPro.TextMeshProUGUI text = obj.GetComponentInChildren<TMPro.TextMeshProUGUI>();
                text.text = p.Position?.AbstractLabel ?? "*";

                Players.Add(p.Id, obj);
            }

            if (p.Coordinate != null)
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
                    Players[p.Id].transform.SetParent(box);

                    Players[p.Id].transform.localPosition = ToDugoutCoordinates(p.Coordinate[1]);
                }
                else
                {
                    var pos = FieldToWorldCoordinates(p.Coordinate[0], p.Coordinate[1], 1);

                    Players[p.Id].transform.localPosition = pos;
                    Players[p.Id].transform.SetParent(Field.transform);
                }
                Players[p.Id].SetActive(true);
            }
            else
            {
                Players[p.Id].SetActive(false);
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
}
