using Fumbbl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

using ApiDto = Fumbbl.Api.Dto;


public class GameBrowserEntry : MonoBehaviour
{
    public Text team1;
    public Image team1Image;
    public Text team1Score;
    public Text team2;
    public Image team2Image;
    public Text team2Score;
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

          //  Fumbbl.FFB.ImageCache.GetOrCreate(t1.logo, () => team1Image);

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

     IEnumerator GetTexture(Image target, string url) {




        UnityWebRequest www = UnityWebRequestTexture.GetTexture("https://www.fumbbl.com/" + url);
        yield return www.SendWebRequest();

        if(www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
        }
        else 
        {
            Texture2D img = ((DownloadHandlerTexture)www.downloadHandler).texture;
            target.sprite = Sprite.Create(img, new Rect(0, 0, img.width, img.height), new Vector2(0, 0));
         
          //  Fumbbl.FFB.ImageCache.GetOrCreate(t1.logo, () => target );

        }
    }
}
