using Fumbbl;
using Fumbbl.Model.Types;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

public class UIScript : MonoBehaviour
{
    public FieldHandler FieldHandler;

    private VisualElement homeCard;
    private VisualElement awayCard;

    private async void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        var button = root.Q<Button>("debug-button");

        homeCard = root.Q<VisualElement>("homepanel");
        awayCard = root.Q<VisualElement>("awaypanel");

        button.RegisterCallback<ClickEvent>(ev => DebugClicked(ev));

        List<Task> tasks = new List<Task>();

        tasks.Add(FFB.Instance.SpriteCache.GetAsync("i/585610"));
        tasks.Add(FFB.Instance.SpriteCache.GetAsync("i/318621"));

        await Task.WhenAll(tasks);
    }

    public void Update()
    {
        homeCard.visible = FieldHandler.homeCardPlayer != null;
        awayCard.visible = FieldHandler.awayCardPlayer != null;
    }

    private void DebugClicked(ClickEvent ev)
    {
        ev.StopPropagation();
        var pos = new Fumbbl.Model.Types.Position();
        pos.IconURL = "i/585610";
        pos.PortraitURL = "i/318621";
        Player p = new Player();
        p.Position = pos;
        p.Id = "Debug Player "+UnityEngine.Random.Range(1, 1000);
        p.Coordinate = new Coordinate(UnityEngine.Random.Range(1,25), UnityEngine.Random.Range(1, 14));
        p.PlayerState = PlayerState.Get(UnityEngine.Random.Range(1, 5));
        FFB.Instance.Model.Add(p);

        var trackNumber = new TrackNumber()
        {
            Coordinate = new Coordinate(UnityEngine.Random.Range(1, 25), UnityEngine.Random.Range(1, 14)),
            Number = UnityEngine.Random.Range(1, 10)
        };
        FFB.Instance.Model.Add(trackNumber);

        var pushbackSquare = new PushbackSquare()
        {
            Coordinate = new Coordinate(UnityEngine.Random.Range(1, 25), UnityEngine.Random.Range(1, 14)),
            Direction = "West"
        };
        FFB.Instance.Model.Add(pushbackSquare);

        FFB.Instance.Model.ActingPlayer.PlayerId = p.Id;
    }
}
