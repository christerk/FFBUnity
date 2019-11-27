using Fumbbl;
using Fumbbl.Api.Dto.Match;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GameBrowserEntry : MonoBehaviour
{
    public TMPro.TextMeshProUGUI team1;
    public Image team1Image;
    public TMPro.TextMeshProUGUI team1Score;
    public TMPro.TextMeshProUGUI team1Info;
    public TMPro.TextMeshProUGUI team2;
    public Image team2Image;
    public TMPro.TextMeshProUGUI team2Score;
    public TMPro.TextMeshProUGUI team2Info;
    public Image progressBar;
    public TMPro.TextMeshProUGUI turnIndicator;

    private Current matchDetails;

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
            team1Info.text = $"({t1.rating}) {t1.coach} TV {t1.tv/1000}k {t1.race}";
            team2Info.text = $"{t2.race} TV {t2.tv / 1000}k {t2.coach} ({t2.rating})";
            turnIndicator.text = $"h{details.half}t{details.turn}";

            float progress = (float)((((float)details.half - 1) * 8) + (float)details.turn) / 16f;
            progressBar.fillAmount = progress;
            StartCoroutine(GetTexture(team1Image, t1.logo));
            StartCoroutine(GetTexture(team2Image, t2.logo));
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

    IEnumerator GetTexture(Image target, string url)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture("https://www.fumbbl.com/" + url);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Texture2D img = ((DownloadHandlerTexture)www.downloadHandler).texture;
            target.sprite = Sprite.Create(img, new Rect(0, 0, img.width, img.height), new Vector2(0, 0));

        }
    }
}
