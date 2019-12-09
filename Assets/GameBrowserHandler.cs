using ApiDto = Fumbbl.Api.Dto;
using Fumbbl;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameBrowserHandler : MonoBehaviour
{

    private FumbblApi api;
    private List<ApiDto.Match.Current> currentMatches;
    private enum Mode
    {
        GameList = 1,
        GameIdInput = 2
    }
    private Mode mode = Mode.GameList;

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

    private void ShowGameIdInput()
    {
        mode = Mode.GameIdInput;
        gameListPanel.SetActive(false);
        gameIdInputField.gameObject.SetActive(true);
        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(gameIdInputField.gameObject);
        gameIdInputField.ActivateInputField();
    }

    private void ShowGameList()
    {
        mode = Mode.GameList;
        gameListPanel.SetActive(true);
        gameIdInputField.gameObject.SetActive(false);
        gameIdInputField.text = "";
        mode = Mode.GameList;
    }


    void Update() {

        if (Input.GetKeyUp(KeyCode.G))
        {
            if (mode is Mode.GameList)
            {
                ShowGameIdInput();
            }
            else if (mode is Mode.GameIdInput)
            {
                ShowGameList();
            }
        }

        if (Input.GetKeyUp(KeyCode.Return))
        {
            if (mode is Mode.GameIdInput)
            {
                FFB.Instance.Stop();
                FFB.Instance.Connect(int.Parse(gameIdInputField.text));
                MainHandler.Instance.SetScene(MainHandler.SceneType.ConnectScene);
                ShowGameList();
            }
        }
    }
}