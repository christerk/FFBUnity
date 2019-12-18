using Fumbbl;
using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginHandler : MonoBehaviour
{
    public TMPro.TMP_InputField CoachField;
    public TMPro.TMP_InputField PasswordField;
    public TMPro.TextMeshProUGUI StatusLabel;
    public UnityEngine.UI.Button LoginButton;
    public string NextScene;

    private enum WorkingMode
        {
            LoggingIn,
            Authenticating
        }

    private bool seriousauth;
    private WorkingMode? currentUIworkingmode;
    private IEnumerator workingUIcoro;

    #region MonoBehaviour Methods

    // Start is called before the first frame update
    private async void Start()
    {
        // The scene is assumed to prohibit interactions at this point.
        // Start is a special case as we try to get authenticated immediately
        // with the stored credentials.
        this.seriousauth = false;
        this.workingUIcoro = null;

        // Setup the input fields.
        CoachField.onSubmit.AddListener(v => { PasswordField.ActivateInputField(); });
        PasswordField.onSubmit.AddListener(v => { Login(); });

        // We subscribed for the Auth events to make the UI update with the
        // result of this authentication attempt.
        FumbblApi.NewAuthResult += OnNewAuthResult;
        FumbblApi.NewLoginResult += OnNewLoginResult;

        // Try to authenticate immediately.
        await TryAuth();
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

    private void DisableInteraction()
    {
        CoachField.interactable = false;
        PasswordField.interactable = false;
        LoginButton.interactable = false;
    }

    private void EnableInteraction()
    {
        CoachField.interactable = true;
        PasswordField.interactable = true;
        LoginButton.interactable = true;
    }

    private void EnsureStoppedWorkingUICoroutine()
    {
        if (workingUIcoro != null)
        {
            StopCoroutine(workingUIcoro);
            workingUIcoro = null;
        }
    }

    public async void Login()
    {
        FumbblApi.LoginResult loginresult = await FFB.Instance.Api.Login(CoachField.text, PasswordField.text);

        switch (loginresult)
        {
            case FumbblApi.LoginResult.LoggedIn:
                // Wait for the "Logged in." statuslabel.
                while (currentUIworkingmode != WorkingMode.Authenticating)
                {
                    await Task.Delay(25);
                }

                await TryAuth();
                // ^We are subscribed to the events it will publish.
                break;
        }
    }

    private IEnumerator OnworkingUIcoroutine(WorkingMode workingmode)
    {
        int ndots = 3;
        string sdots;
        string statuslabelrootstring = String.Empty;
        switch (workingmode)
        {
            case WorkingMode.LoggingIn:
                statuslabelrootstring = "Logging in";
                break;
            case WorkingMode.Authenticating:
                statuslabelrootstring = "Authenticating";
                break;
        }
        while (true)
        {
            sdots = new String('.', ndots);
            StatusLabel.text = $"{statuslabelrootstring}{sdots}";
            ndots = (++ndots - 2) % 2 + 2;
            yield return new WaitForSeconds(1f);
        }
    }

    protected virtual async void OnNewAuthResult(object source, FumbblApi.AuthResultArgs args)
    {
        EnsureStoppedWorkingUICoroutine();
        switch (args.AuthResult)
        {
            case FumbblApi.AuthResult.Authenticating:
                StatusLabel.text = "Authenticating...";
                StatusLabel.color = new Color(1f,1f,1f);
                DisableInteraction();
                workingUIcoro = OnworkingUIcoroutine(WorkingMode.Authenticating);
                StartCoroutine(workingUIcoro);
                break;
            case FumbblApi.AuthResult.Authenticated:
                StatusLabel.text = "Authenticated.";
                StatusLabel.color = new Color(1f,1f,1f);
                DisableInteraction();
                await Task.Delay(1000);
                SceneManager.LoadScene(NextScene);
                break;
            case FumbblApi.AuthResult.AuthenticationFailed:
                if (seriousauth)
                {
                    StatusLabel.text = "Authentication failed.";
                    StatusLabel.color = new Color(1f,0.8f,0f);
                }
                else
                {
                    StatusLabel.text = "";
                    StatusLabel.color = new Color(1f,1f,1f);
                    seriousauth = true;
                }
                EnableInteraction();
                CoachField.ActivateInputField();
                break;
            case FumbblApi.AuthResult.ConnectionFailed:
                StatusLabel.text = "Connection failed.";
                StatusLabel.color = new Color(1f,0f,0f);
                EnableInteraction();
                break;
        }
    }

    protected virtual async void OnNewLoginResult(object source, FumbblApi.LoginResultArgs args)
    {
        EnsureStoppedWorkingUICoroutine();
        currentUIworkingmode = null;
        switch (args.LoginResult)
        {
            case FumbblApi.LoginResult.LoggingIn:
                currentUIworkingmode = WorkingMode.LoggingIn;
                StatusLabel.text = "Logging in...";
                StatusLabel.color = new Color(1f,1f,1f);
                DisableInteraction();
                workingUIcoro = OnworkingUIcoroutine(WorkingMode.LoggingIn);
                StartCoroutine(workingUIcoro);
                break;
            case FumbblApi.LoginResult.LoggedIn:
                StatusLabel.text = "Logged in.";
                StatusLabel.color = new Color(1f,1f,1f);
                DisableInteraction();
                await Task.Delay(1000);
                currentUIworkingmode = WorkingMode.Authenticating;
                break;
            case FumbblApi.LoginResult.LoginFailed:
                StatusLabel.text = "Login failed.";
                StatusLabel.color = new Color(1f,0.8f,0f);
                EnableInteraction();
                CoachField.ActivateInputField();
                break;
            case FumbblApi.LoginResult.ConnectionFailed:
                StatusLabel.text = "Connection failed.";
                StatusLabel.color = new Color(1f,0f,0f);
                EnableInteraction();
                break;
        }
    }

    private async Task TryAuth()
    {
        string clientId = PlayerPrefs.GetString("OAuth.ClientId");
        string clientSecret = PlayerPrefs.GetString("OAuth.ClientSecret");
        await FFB.Instance.Authenticate(clientId, clientSecret);
    }
}
