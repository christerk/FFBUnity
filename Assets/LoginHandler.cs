using Fumbbl;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginHandler : MonoBehaviour
{
    public TMPro.TMP_InputField CoachField;
    public TMPro.TMP_InputField PasswordField;
    public TMPro.TextMeshProUGUI StatusLabel;
    public string NextScene;

    #region MonoBehaviour Methods

    // Start is called before the first frame update
    private void Start()
    {
        if (StatusLabel != null)
        {
            StatusLabel.text = "Logging in...";
            StatusLabel.color = new Color(1f,1f,1f);
        }

        string clientId = PlayerPrefs.GetString("OAuth.ClientId");
        string clientSecret = PlayerPrefs.GetString("OAuth.ClientSecret");
        //return await FFB.Instance.Authenticate(clientId, clientSecret);
        Task<FumbblApi.LoginResult> task = Task.Run<FumbblApi.LoginResult>(async () => await FFB.Instance.Authenticate(clientId, clientSecret));
        //Task<FumbblApi.LoginResult> task = Task.Run<FumbblApi.LoginResult>(async () => await TryLogin());
        var loginresult = task.Result;
        if (
                (CoachField != null && PasswordField != null)
                && (string.IsNullOrEmpty(CoachField.text) || string.IsNullOrEmpty(PasswordField.text))
                && (loginresult == FumbblApi.LoginResult.AuthenticationFailed)
        )
        {
            if (StatusLabel != null)
            {
                StatusLabel.text = "Please authenticate yourself.";
                StatusLabel.color = new Color(1f,1f,1f);
            }
        }
        else{
            UpdateStatusLabel(loginresult);
        }


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
        StatusLabel.text = "Logging in...";
        StatusLabel.color = new Color(1f,1f,1f);

        FumbblApi.LoginResult loginresult = await FFB.Instance.Api.Login(CoachField.text, PasswordField.text);

        if (loginresult == FumbblApi.LoginResult.Authenticated)
        {
            loginresult = await TryLogin();
        }
        UpdateStatusLabel(loginresult);
        if (loginresult == FumbblApi.LoginResult.AuthenticationFailed)
        {
            CoachField.ActivateInputField();
        }
    }

    private void UpdateStatusLabel(FumbblApi.LoginResult loginresult)
    {
        if (StatusLabel != null)
        {
            switch (loginresult)
            {
                case FumbblApi.LoginResult.Authenticated:
                    StatusLabel.text = "Authenticated.";
                    StatusLabel.color = new Color(1f,1f,1f);
                    SceneManager.LoadScene(NextScene);
                    break;
                case FumbblApi.LoginResult.AuthenticationFailed:
                    StatusLabel.text = "Authentication failed.";
                    StatusLabel.color = new Color(1f,0.8f,0f);
                    break;
                case FumbblApi.LoginResult.ConnectionFailed:
                    StatusLabel.text = "Connection failed.";
                    StatusLabel.color = new Color(1f,0f,0f);
                    break;
            }
        }
    }

    private async Task<FumbblApi.LoginResult> TryLogin()
    {
        string clientId = PlayerPrefs.GetString("OAuth.ClientId");
        string clientSecret = PlayerPrefs.GetString("OAuth.ClientSecret");
        return await FFB.Instance.Authenticate(clientId, clientSecret);
    }
}
