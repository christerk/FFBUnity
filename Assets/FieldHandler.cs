using Fumbbl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldHandler : MonoBehaviour
{
    public GameObject PlayerIconPrefab;
    public GameObject Field;

    private static Color HomeColour = new Color(0.66f, 0.19f, 0.19f);
    private static Color AwayColour = new Color(0f, 0f, 1f);

    private Dictionary<string, GameObject> Players;

    // Start is called before the first frame update
    void Start()
    {
        Players = new Dictionary<string, GameObject>();
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
                Renderer s = obj.GetComponent<Renderer>();
                s.material.color = p.IsHome ? HomeColour : AwayColour;
                Players.Add(p.Id, obj);
            }

            if (p.Coordinate != null)
            {
                var pos = Players[p.Id].transform.localPosition;

                pos.x = p.Coordinate[0] * 144 - 13 * 144 + 72;
                pos.y = -p.Coordinate[1] * 144 + 7 * 144 + Field.transform.localPosition.y;

                Players[p.Id].transform.localPosition = pos;
                Players[p.Id].SetActive(true);
            }
            else
            {
                Players[p.Id].SetActive(false);
            }
        }
    }
}
