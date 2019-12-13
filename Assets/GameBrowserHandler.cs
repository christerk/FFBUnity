using ApiDto = Fumbbl.Api.Dto;
using Fumbbl;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameBrowserHandler : MonoBehaviour
{
    private FumbblApi api;
    private List<ApiDto.Match.Current> currentMatches;
    private Mode mode = Mode.GameList;

    private enum Mode
    {
        GameList,
        GameIdInput
    }

    public GameObject button;
    public GameObject gameListPanel;
    public GameObject pane;
    public TMP_InputField gameIdInputField;



    ///////////////////////////////////////////////////////////////////////////
    //  MONOBEHAVIOUR METHODS  ////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////

    private void Start()
    {
        Debug.Log("Initialise Game Browser");
        api = new FumbblApi();
        RefreshMatches();
        gameIdInputField.onValidateInput += (text, charIndex, addedChar) =>
        {
            if (addedChar < '0' || addedChar > '9')
            {
                return '\0';
            }
            return addedChar;
        };
    }

    private void Update() {

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



    ///////////////////////////////////////////////////////////////////////////
    //  CUSTOM METHODS  ///////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////

    private void RefreshMatches()
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
}
