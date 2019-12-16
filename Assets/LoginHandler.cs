using Fumbbl;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginHandler : MonoBehaviour
{
    public GameObject LoggingInLabel;
    public GameObject LoginErrorLabel;
    public GameObject LoginPanel;
    public TMPro.TMP_InputField CoachField;
    public TMPro.TMP_InputField PasswordField;
    public string NextScene;

    #region MonoBehaviour Methods

    // Start is called before the first frame update
    private void Start()
    {
        TryLogin();
        LoginErrorLabel.SetActive(false);

        if (CoachField != null)
        {
            CoachField.onSubmit.AddListener(v =>
            {
                PasswordField.ActivateInputField();
            });
            CoachField.ActivateInputField();
        }
        if (PasswordField != null)
        {
            PasswordField.onSubmit.AddListener(v =>
            {
                Login();
            });
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (CoachField.isFocused)
            {
                PasswordField.ActivateInputField();
            }
            else
            {
                CoachField.ActivateInputField();
            };
        }
    }

    #endregion

    public async void Login()
    {
        FumbblApi.LoginResult loginresult = await FFB.Instance.Api.Login(CoachField.text, PasswordField.text);

        if (loginresult == FumbblApi.LoginResult.Authenticated)
        {
            TryLogin();
        }
        else
        {
            CoachField.ActivateInputField();
            ShowLoginError();
        }
    }

    private async void TryLogin()
    {
        string clientId = PlayerPrefs.GetString("OAuth.ClientId");
        string clientSecret = PlayerPrefs.GetString("OAuth.ClientSecret");

        LoginPanel.SetActive(false);
        LoggingInLabel.SetActive(true);
        LoginErrorLabel.SetActive(false);
        FumbblApi.LoginResult loginresult = await FFB.Instance.Authenticate(clientId, clientSecret);

        if (loginresult == FumbblApi.LoginResult.Authenticated)
        {
            SceneManager.LoadScene(NextScene);
        }
        else
        {
            LoginPanel.SetActive(true);
            LoggingInLabel.SetActive(false);
        }
    }

    private void ShowLoginError()
    {
        LoginErrorLabel.SetActive(true);
        LoggingInLabel.SetActive(false);
    }
}
