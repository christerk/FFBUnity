using Fumbbl;
using Fumbbl.View;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FieldHandler : MonoBehaviour
{
    public GameObject PlayerIconPrefab;
    public GameObject Field;
    public GameObject BallPrefab;
    public GameObject ArrowPrefab;

    private static Color HomeColour = new Color(0.66f, 0.19f, 0.19f);
    private static Color AwayColour = new Color(0f, 0f, 1f);

    private Dictionary<string, GameObject> Players;
    private GameObject Ball;
    private ViewObjectList<PushbackSquare> PushbackSquares;

    // Start is called before the first frame update
    void Start()
    {
        Players = new Dictionary<string, GameObject>();
        Ball = Instantiate(BallPrefab);
        PushbackSquares = new ViewObjectList<PushbackSquare>(s =>
        {
            s.GameObject = Instantiate(ArrowPrefab);
        },
        s =>
        {
            Destroy(s.GameObject);
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
                var pos = FieldToWorldCoordinates(p.Coordinate[0], p.Coordinate[1], 1);

                Players[p.Id].transform.localPosition = pos;
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
                s.GameObject.transform.localPosition = FieldToWorldCoordinates(s.Coordinate[0], s.Coordinate[1], 10);
            }
        }
    }

    internal Vector3 FieldToWorldCoordinates(float x, float y, float z)
    {
        x = x * 144 - 13 * 144 + 72;
        y = -y * 144 + 7 * 144 + Field.transform.localPosition.y;

        return new Vector3(x, y, z);
    }


}
