using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBrowserEntry : MonoBehaviour
{

    public GameObject team1;
    public GameObject team1Image;
    public GameObject team2;
    public GameObject team2Image;

    private Api.Dto.Match.Current matchDetails;

    public void SetMatchDetails(Api.Dto.Match.Current details)
    {
        matchDetails = details;
        Text team1Name = team1.GetComponent<Text>();
        team1Name.text = "test";
    }
}
