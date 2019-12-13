using Fumbbl;
using Fumbbl.Api.Dto.Match;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GameBrowserEntry : MonoBehaviour
{
    private Current matchDetails;

    public Image progressBar;
    public Image team1Image;
    public Image team2Image;
    public TMPro.TextMeshProUGUI team1;
    public TMPro.TextMeshProUGUI team1Info;
    public TMPro.TextMeshProUGUI team1Score;
    public TMPro.TextMeshProUGUI team2;
    public TMPro.TextMeshProUGUI team2Info;
    public TMPro.TextMeshProUGUI team2Score;
    public TMPro.TextMeshProUGUI turnIndicator;



    ///////////////////////////////////////////////////////////////////////////
    //  MONOBEHAVIOUR METHODS  ////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////

    public void OnClick()
    {
        FFB.Instance.Stop();
        FFB.Instance.Connect(matchDetails.id);
        MainHandler.Instance.SetScene(MainHandler.SceneType.ConnectScene);
    }



    ///////////////////////////////////////////////////////////////////////////
    //  CUSTOM METHODS  ///////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////

    public void SetMatchDetails(Current details)
    {
        if (details.teams.Count == 2)
        {
            Team t1 = details.teams[0];
            Team t2 = details.teams[1];
            matchDetails = details;
            team1.text = t1.name;
            team2.text = t2.name;
            team1Score.text = t1.score.ToString();
            team2Score.text = t2.score.ToString();
            team1Info.text = $"({t1.rating}) {t1.coach} TV {t1.tv / 1000}k {t1.race}";
            team2Info.text = $"{t2.race} TV {t2.tv / 1000}k {t2.coach} ({t2.rating})";
            turnIndicator.text = $"h{details.half}t{details.turn}";

            float progress = (float)((((float)details.half - 1) * 8) + (float)details.turn) / 16f;
            progressBar.fillAmount = progress;

            FumbblApi.GetImage(t1.logolarge, team1Image);
            FumbblApi.GetImage(t2.logolarge, team2Image);
        }
        else
        {
            Debug.LogError("Invalid number of teams found when parsing match details");
        }
    }
}
