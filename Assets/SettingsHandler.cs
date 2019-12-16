using Fumbbl;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsHandler : MonoBehaviour
{
    public GameObject currentPanel;
    public GameObject initialPanel;

    // Graphics Panel
    public TMP_Dropdown resolutions;
    public Toggle AbstractIconsToggle;
    public Toggle fullscreenToggle;

    // Sound Panel
    public Slider VolumeSlider;
    public Toggle SoundMuteToggle;

    // DebugPanel
    public TMP_InputField clientId;
    public TMP_InputField clientSecret;

    private readonly Dictionary<string, List<Resolution>> RDict = new Dictionary<string, List<Resolution>>();

    #region MonoBehaviour Methods

    private void Start()
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
        initialPanel.SetActive(true);
        AbstractIconsToggle.isOn = FFB.Instance.Settings.Graphics.AbstractIcons;
        SoundMuteToggle.isOn = !FFB.Instance.Settings.Sound.Mute;
        VolumeSlider.value = FFB.Instance.Settings.Sound.GlobalVolume;
    }

    #endregion

    #region Graphics Panel Methods

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

    public void UpdateAbstractIcons()
    {
        FFB.Instance.Settings.Graphics.AbstractIcons = AbstractIconsToggle.isOn;
        FFB.Instance.Settings.Save();
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

    #endregion

    #region Sound Panel Methods

    public void UpdateEnableSound()
    {
        FFB.Instance.Settings.Sound.Mute = !SoundMuteToggle.isOn;
        FFB.Instance.Settings.Save();
    }

    public void UpdateVolume()
    {
        FFB.Instance.Settings.Sound.GlobalVolume = VolumeSlider.value;
        FFB.Instance.Settings.Save();
    }

    #endregion

    #region Debug Panel Methods

    public void SetOAuth()
    {
        PlayerPrefs.SetString("OAuth.ClientId", clientId.text);
        PlayerPrefs.SetString("OAuth.ClientSecret", clientSecret.text);
    }

    #endregion

    public void Logout()
    {
        FFB.Instance.Stop();
        PlayerPrefs.DeleteKey("OAuth.ClientId");
        PlayerPrefs.DeleteKey("OAuth.ClientSecret");
        MainHandler.Instance.SetScene(MainHandler.SceneType.LoginScene);
    }

    public void Quit()
    {
        FFB.Instance.Stop();
        MainHandler.Instance.QuitGame();
    }

    public void ShowPanel(GameObject panel)
    {
        Debug.Log(GetHashCode());
        if (panel != currentPanel)
        {
            if (currentPanel != null)
            {
                currentPanel.GetComponent<Animator>().SetTrigger("Hide");
            }
            panel.GetComponent<Animator>().SetTrigger("Show");
            currentPanel = panel;
        }
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

    public void SwitchToLoginScene()
    {
        MainHandler.Instance.SetScene(MainHandler.SceneType.LoginScene);
    }

    public void SwitchToPreviousScene()
    {
        MainHandler.Instance.SetScene(FFB.Instance.PreviousScene);
    }









}
