using ApiDto = Fumbbl.Api.Dto;
using Fumbbl;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Threading.Tasks;
using Fumbbl.View;
using System.Linq;

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
    private HashSet<string> Friends;

    private ViewObjectList<BrowserRecord> Matches;

    private enum Mode
    {
        GameList,
        GameIdInput
    }

    #region MonoBehaviour Methods

    private async void Start()
    {
        Matches = new ViewObjectList<BrowserRecord>(
            r =>
            {
                GameObject newButton = Instantiate(button);
                newButton.transform.SetParent(pane.transform, false);

                var div = r.Record.division;
                // Find position of new game
                bool foundSection = false;
                int position = -1;
                for(int i=0; i<pane.transform.childCount; i++)
                {
                    var currentMatch = pane.transform.GetChild(i).GetComponent<GameBrowserEntry>()?.matchDetails;

                    if (currentMatch != null)
                    {
                        if (!foundSection)
                        {
                            if (string.Equals(currentMatch.division, div))
                            {
                                foundSection = true;
                            }
                        }
                        else
                        {
                            if (!string.Equals(currentMatch.division, div))
                            {
                                position = i;
                                break;
                            }
                        }
                    }
                    else
                    {
                        // This is a division divider
                        if (foundSection)
                        {
                            position = i;
                            break;
                        }
                    }
                }
                if (position >= 0)
                {
                    newButton.transform.SetSiblingIndex(position);
                }
                else if (!foundSection)
                {
                    GameObject divider = Instantiate(this.divider);
                    divider.transform.SetParent(pane.transform, false);
                    divider.transform.SetSiblingIndex(pane.transform.childCount - 2);
                    divider.transform.GetChild(1).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = div;
                }

                newButton.GetComponent<GameBrowserEntry>().SetMatchDetails(r.Record, Friends);
                return newButton;
            },
            r =>
            {
                r.GameObject.GetComponent<GameBrowserEntry>().SetMatchDetails(r.ModelObject.Record, Friends);
            },
            r =>
            {
                Destroy(r.GameObject);
            }
        );

        LogManager.Debug("Initialise Game Browser");
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

        Friends = await LoadFriends();

        InvokeRepeating("RefreshMatches", 3f, 3f);
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

        if (Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(KeyCode.KeypadEnter))
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
        currentMatches = await api.GetCurrentMatches();
        string previousDivision = string.Empty;

        Matches.Refresh(currentMatches.Select(m => new BrowserRecord(m)));
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

    private class BrowserRecord : IKeyedObject<BrowserRecord>
    {
        public ApiDto.Match.Current Record;
        public object Key => Record.id;

        public BrowserRecord(ApiDto.Match.Current record)
        {
            Record = record;
        }

        public void Refresh(BrowserRecord data)
        {
            Record.id = data.Record.id;
            Record.division = data.Record.division;
            Record.half = data.Record.half;
            Record.teams = data.Record.teams;
            Record.tournament = data.Record.tournament;
            Record.turn = data.Record.turn;
        }
    }
}
