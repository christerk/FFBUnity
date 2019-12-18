using ApiDto = Fumbbl.Api.Dto;
using Fumbbl;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Threading.Tasks;

public class GameBrowserHandler : MonoBehaviour
{
    public GameObject button;
    public GameObject divider;
    public GameObject gameListPanel;
    public GameObject pane;
    public TMP_InputField gameIdInputField;

    private FumbblApi api;
    private List<ApiDto.Match.Current> currentMatches;
    private Mode mode = Mode.GameList;

    private enum Mode
    {
        GameList,
        GameIdInput
    }

    #region MonoBehaviour Methods

    private void Start()
    {
        Debug.Log("Initialise Game Browser");
        api = FFB.Instance.Api;
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

    #endregion

    private async Task<HashSet<string>> LoadFriends()
    {
        var friends = new HashSet<string>();
        var list = await api.GetFriends();
        foreach (var friend in list)
        {
            friends.Add(friend);
        }
        return friends;
    }

    private async void RefreshMatches()
    {
        var friends = await LoadFriends();
        currentMatches = await api.GetCurrentMatches();
        string previousDivision = string.Empty;
        foreach (ApiDto.Match.Current match in currentMatches)
        {
            if (!string.Equals(previousDivision, match.division))
            {
                GameObject divider = Instantiate(this.divider);
                divider.transform.SetParent(pane.transform, false);
                divider.transform.GetChild(1).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = match.division;
                previousDivision = match.division;
            }
            GameObject newButton = Instantiate(button);
            newButton.transform.SetParent(pane.transform, false);
            newButton.GetComponent<GameBrowserEntry>().SetMatchDetails(match, friends);
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
