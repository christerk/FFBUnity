using Fumbbl;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsHandler : MonoBehaviour
{
    public Toggle fullscreenToggle;
    public TMP_Dropdown resolutions;
    public TMP_InputField clientId;
    public TMP_InputField clientSecret;

    private readonly Dictionary<string, List<Resolution>> RDict = new Dictionary<string, List<Resolution>>();

    void Start()
    {
        fullscreenToggle.isOn = Screen.fullScreen;

        List<string> options = new List<string>();

        foreach (Resolution r in Screen.resolutions)
        {
            if (AllowResolution(r))
            {
                string key = $"{r.width}x{r.height}";
                if (!RDict.ContainsKey(key))
                {
                    RDict.Add(key, new List<Resolution>());
                    options.Add(key);
                }
                RDict[key].Add(r);
            }
        }

        options.Sort((a, b) => { return GetResolutionKey(RDict[b][0]) - GetResolutionKey(RDict[a][0]); });

        int closestDistance = int.MaxValue;
        int closest = 0;
        for (int i = 0; i < options.Count; i++)
        {
            string res = options[i];
            int dist = Mathf.Abs(GetResolutionKey(RDict[res][0]) - GetResolutionKey(Screen.width, Screen.height));
            if (dist < closestDistance)
            {
                closest = i;
                closestDistance = dist;
            }
            RDict[res].Sort((a, b) => b.refreshRate - a.refreshRate);
            resolutions.options.Add(new TMP_Dropdown.OptionData(res));
        }

        resolutions.value = closest;
        UpdateResolution();

        clientId.text = PlayerPrefs.GetString("OAuth.ClientId");
        clientSecret.text = PlayerPrefs.GetString("OAuth.ClientSecret");
    }

    private bool AllowResolution(Resolution r)
    {
        return r.width >= 1024 && r.height >= 768;
    }

    private int GetResolutionKey(Resolution r)
    {
        return GetResolutionKey(r.width, r.height);
    }
    private int GetResolutionKey(int width, int height)
    {
        return width * 100000 + height;
    }

    public void SetOAuth()
    {
        PlayerPrefs.SetString("OAuth.ClientId", clientId.text);
        PlayerPrefs.SetString("OAuth.ClientSecret", clientSecret.text);
    }

    public void SwitchToGameBrowser()
    {
        FFB.Instance.Stop();
        MainHandler.Instance.SetScene(MainHandler.SceneType.GameBrowserScene);
    }

    public void SwitchToMainScene()
    {
        MainHandler.Instance.SetScene(MainHandler.SceneType.MainScene);
    }

    public void Quit()
    {
        MainHandler.Instance.QuitGame();
    }

    public void UpdateResolution()
    {
        if (resolutions.options.Count > 0)
        {
            if (fullscreenToggle.isOn)
            {
                resolutions.value = 0;
            }

            string selectedResolution = resolutions.options[resolutions.value].text;
            Debug.Log($"Current Resoltion {selectedResolution}");
            Resolution r = RDict[selectedResolution][0];
            Screen.SetResolution(r.width, r.height, fullscreenToggle.isOn, r.refreshRate);
        }
        resolutions.gameObject.SetActive(!fullscreenToggle.isOn);
    }

    public void Logout()
    {
        PlayerPrefs.DeleteKey("OAuth.ClientId");
        PlayerPrefs.DeleteKey("OAuth.ClientSecret");
        MainHandler.Instance.SetScene(MainHandler.SceneType.LoginScene);
    }
}
