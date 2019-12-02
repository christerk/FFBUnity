using Fumbbl;
using Fumbbl.Ffb.Dto;
using Fumbbl.Ffb.Dto.Reports;
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

    private static Color HomeColour = new Color(0.66f, 0.19f, 0.19f, 1f);
    private static Color AwayColour = new Color(0f, 0f, 0.99f, 1f);

    private Dictionary<string, GameObject> Players;
    private GameObject Ball;
    private ViewObjectList<PushbackSquare> PushbackSquares;
    private ViewObjectList<TrackNumber> TrackNumbers;

    // Start is called before the first frame update
    void Start()
    {
        FFB.Instance.OnReport += AddReport;

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
                var text = scrollText.GetComponentInChildren<TMPro.TextMeshProUGUI>();
                text.text = action.ShortDescription;
                Vector3 coords = FieldToWorldCoordinates(player.Coordinate[0], player.Coordinate[1], 5);
                coords.y += 100;
                scrollText.gameObject.transform.localPosition = coords;
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

        var players = FFB.Instance.Model.GetPlayers();

        int playerNum = 0;
        foreach (var p in players)
        {
            playerNum++;
            if (!Players.ContainsKey(p.Id))
            {
                //GameObject obj = GenerateAbstractIcon(p);
                GameObject obj = GeneratePlayerIcon(p, playerNum);

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

    private GameObject GeneratePlayerIcon(Player p, int playerNum)
    {
        GameObject obj = Instantiate(PlayerIconPrefab);
        var handler = obj.GetComponent<PlayerHandler>();
        obj.transform.SetParent(Field.transform);
        handler.Player = p;
        obj.name = p.Id;

        SpriteMask mask = obj.GetComponent<SpriteMask>();
        mask.frontSortingOrder = playerNum;
        mask.backSortingOrder = playerNum - 1;
        mask.isCustomRangeActive = true;

        var target = obj.transform.GetChild(0).gameObject;

        float x = p.IsHome ? 192 * 1.5f : 192 * -0.5f;
        target.transform.localPosition = new Vector3(x, 0, 0);

        LoadSprite(p.Position.IconURL, target, playerNum);

        return obj;
    }

    private async void LoadSprite(string iconURL, GameObject target, int orderInLayer)
    {
        var renderer = target.GetComponent<SpriteRenderer>();
        renderer.sortingOrder = orderInLayer;

        Sprite s = await FumbblApi.GetSpriteAsync(iconURL);
        var iconSize = s.texture.width / 4;
        int numTextures = s.texture.height / iconSize;

        Sprite resized = ResizeSprite(s);
        resized.name = s.name;
        renderer.sprite = resized;

        float maskSize = 192; // 144 * 40/30, 40 pixel equivalent squares.

        float y = 192*numTextures/2 - maskSize * 0.5f;

        target.transform.localPosition = new Vector3(target.transform.localPosition.x, y, 0);
        RectTransform rect = target.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(maskSize, maskSize);
    }

    private Sprite ResizeSprite(Sprite s)
    {
        s.texture.filterMode = FilterMode.Point;
        var srcIconSize = s.texture.width / 4;
        var numIcons = s.texture.height / srcIconSize;

        var srcMipLevels = s.texture.mipmapCount;

        Texture2D dest = new Texture2D(160, 40 * numIcons, s.texture.format, srcMipLevels, true);

        Color transparent = new Color(0f, 0f, 0f, 0f);
        dest.alphaIsTransparency = true;

        for (int mip = 0; mip < srcMipLevels; mip++)
        {
            Color[] data = dest.GetPixels(mip);
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = Color.clear;
            }
            dest.SetPixels(data, mip);
        }

        var destMip = 0;
        for (int y = 0; y < numIcons; y++)
        {
            for (int x = 0; x < 4; x++)
            {
                Graphics.CopyTexture(
                    s.texture, 0, destMip, x * srcIconSize, y * srcIconSize, srcIconSize, srcIconSize,
                    dest, 0, destMip, x * 40 + (40 - srcIconSize) / 2, y * 40 + (40 - srcIconSize) / 2
                );
            }
        }

        // TODO: This should be a "Icon Scaling Mode" setting
        //dest.filterMode = FilterMode.Point;
        dest.Apply();
        return Sprite.Create(dest, new Rect(0, 0, dest.width, dest.height), new Vector2(0.5f, 0.5f), 1f, 0, SpriteMeshType.FullRect);
    }

    private GameObject GenerateAbstractIcon(Player p)
    {
        GameObject obj = Instantiate(AbstractIconPrefab);
        var handler = obj.GetComponent<PlayerHandler>();
        obj.transform.SetParent(Field.transform);
        handler.Player = p;
        obj.name = p.Id;

        // Set Background colour
        var child = obj.transform.GetChild(0).gameObject;
        Renderer s = child.GetComponent<Renderer>();
        s.material.color = p.IsHome ? HomeColour : AwayColour;

        // Set text
        TMPro.TextMeshProUGUI text = obj.GetComponentInChildren<TMPro.TextMeshProUGUI>();
        text.text = p.Position?.AbstractLabel ?? "*";
        return obj;
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
