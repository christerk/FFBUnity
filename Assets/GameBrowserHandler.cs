using System.Collections.Generic;
using UnityEngine;
using ApiDto = Fumbbl.Api.Dto;

public class GameBrowserHandler : MonoBehaviour
{

    private FumbblApi api;
    private List<ApiDto.Match.Current> currentMatches;

    public GameObject pane;
    public GameObject button;

    void Start()
    {
        Debug.Log("Initialise Game Browser");
        api = new FumbblApi();
        RefreshMatches();
    }

    void RefreshMatches()
    {
        currentMatches = api.GetCurrentMatches();
        foreach (ApiDto.Match.Current match in currentMatches)
        {
            GameObject newButton = Instantiate(button) as GameObject;
            newButton.transform.SetParent(pane.transform, false);
            newButton.GetComponent<GameBrowserEntry>().SetMatchDetails(match);
        }
    }
}
