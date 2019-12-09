using ApiDto = Fumbbl.Api.Dto;
using Fumbbl;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameBrowserHandler : MonoBehaviour
{

    private FumbblApi api;
    private KeyCode? control = null;
    private List<ApiDto.Match.Current> currentMatches;
    private enum Mode
    {
        GameList = 1,
        GameIdInput = 2
    }
    private Mode mode;

    public GameObject pane;
    public GameObject button;
    public GameObject gameListPanel;
    public TMP_InputField gameIdInputField;

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

    void Update() {

        if (control is null)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                control = KeyCode.LeftControl;
            }
            else if (Input.GetKeyDown(KeyCode.RightControl))
            {
                control = KeyCode.RightControl;
            }
        }
        else
        {
            if (Input.GetKeyUp((KeyCode)control))
            {
                control = null;
            }
        }

        if ((control != null) && (Input.GetKeyUp(KeyCode.G)))
        {
            bool showgameIdInputField = gameListPanel.active;
            gameListPanel.SetActive(!showgameIdInputField);
            gameIdInputField.gameObject.SetActive(showgameIdInputField);
            Debug.Log(showgameIdInputField);
            if (showgameIdInputField)
            {
                UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(gameIdInputField.gameObject);
                gameIdInputField.ActivateInputField();
                mode = Mode.GameIdInput;
            }
            else
            {
                gameIdInputField.text = "";
                mode = Mode.GameList;
            }
        }

        if (mode is Mode.GameIdInput)
        {
            if (Input.GetKeyUp(KeyCode.Return))
            {
                FFB.Instance.Stop();
                FFB.Instance.Connect(int.Parse(gameIdInputField.text));
                MainHandler.Instance.SetScene(MainHandler.SceneType.ConnectScene);
            }
        }
    }
}
