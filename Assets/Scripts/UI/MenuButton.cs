using Fumbbl;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    public void SwitchToSettingsScene()
    {
        MainHandler.Instance.SetScene(MainHandler.SceneType.SettingsScene);
    }
}
