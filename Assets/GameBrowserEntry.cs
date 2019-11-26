using Fumbbl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

using ApiDto = Fumbbl.Api.Dto;


public class GameBrowserEntry : MonoBehaviour
{
    public TMPro.TextMeshProUGUI team1;
    public Image team1Image;
    public TMPro.TextMeshProUGUI team1Score;
    public TMPro.TextMeshProUGUI team2;
    public Image team2Image;
    public TMPro.TextMeshProUGUI team2Score;
    public Image progressBar;

    private ApiDto.Match.Current matchDetails;

    public void SetMatchDetails(ApiDto.Match.Current details)
    {
        if(details.teams.Count == 2)
        {
            ApiDto.Match.Team t1 = details.teams[0];
            ApiDto.Match.Team t2 = details.teams[1];
            matchDetails = details;
            team1.text = t1.name;
            team2.text = t2.name;
            team1Score.text = t1.score.ToString();
            team2Score.text = t2.score.ToString();

            float progress = (float)((((float)details.half -1) * 8) + (float)details.turn) / 16f;
            progressBar.fillAmount = progress;

            GetImage(t1.logo, team1Image);
            GetImage(t2.logo, team2Image);
        }
        else
        {
            Debug.LogError("Invalid number of teams found when parsing match details");
        }
    }

    public void OnClick()
    {
        Debug.Log("clicked game: " + matchDetails.id);
        FFB.Instance.Connect(matchDetails.id);
        MainHandler.Instance.SetScene(MainHandler.SceneType.MainScene);
    }

    public async void GetImage(string url, Image target)
    {
        target.sprite = await FFB.Instance.SpriteCache.GetAsync(url, FFB.Instance.Api.GetSpriteAsync);
    }

}
