using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Api.Dto;

public class GameBrowserHandler : MonoBehaviour
{

    private FumbblApi api;
    private List<Api.Dto.Match.Current> currentMatches;
  
    public GameObject pane;
    public GameObject button;

 
    // Start is called before the first frame update
    void Start()
    {
       Debug.Log("Initialise Game Browser");
       api = new FumbblApi();
       RefreshMatches();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RefreshMatches()
    {
       currentMatches = api.GetCurrentMatches();
       foreach(Api.Dto.Match.Current match in currentMatches)
       {
          Debug.Log(match.id); 
          GameObject newButton = Instantiate(button) as GameObject;
          newButton.transform.SetParent(pane.transform, false);
       }
    }
}
