using Fumbbl;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginHandler : MonoBehaviour
{
    public TMPro.TMP_InputField CoachField;
    public TMPro.TMP_InputField PasswordField;
    public TMPro.TextMeshProUGUI StatusLabel;
    public UnityEngine.UI.Button LoginButton;
    public GameObject StatusPanel;
    public GameObject BigSpinner;
    public GameObject SmallSpinner;
    public string NextScene;

    private GameObject ActiveSpinner;
    private IEnumerator ActiveSpinnerCoro;

    #region MonoBehaviour Methods

    // Start is called before the first frame update
    private async void Start()
    {
        StatusPanel.SetActive(false);

        CoachField.onSubmit.AddListener(v => { PasswordField.ActivateInputField(); });
        PasswordField.onSubmit.AddListener(v => { Login(); });

        FumbblApi.NewAuthResult += OnNewAuthResult;
        FumbblApi.NewLoginResult += OnNewLoginResult;

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

    private void OnDestroy()
    {
        FumbblApi.NewAuthResult -= OnNewAuthResult;
        FumbblApi.NewLoginResult -= OnNewLoginResult;
    }

    #endregion

    public async void Login()
    {
        FumbblApi.LoginResult loginresult = await FFB.Instance.Api.Login(CoachField.text, PasswordField.text);

        switch (loginresult)
        {
            case FumbblApi.LoginResult.LoggedIn:
                await TryAuth();
                break;
        }
    }

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

    private void EnsureNoSpinner()
    {
        if (ActiveSpinnerCoro != null)
        {
            StopCoroutine(ActiveSpinnerCoro);
        }
        if (ActiveSpinner != null)
        {
            ActiveSpinner.SetActive(false);
            ActiveSpinner = null;
        }
    }

    private void EnsureDelayedSpinner()
    {
        if (ActiveSpinnerCoro == null)
        {
            ActiveSpinnerCoro = SpinnerCoro();
            StartCoroutine(ActiveSpinnerCoro);
        };
    }

    protected virtual void OnNewAuthResult(object source, FumbblApi.AuthResultArgs args)
    {
        switch (args.AuthResult)
        {
            case FumbblApi.AuthResult.MissingCondition:
                EnsureNoSpinner();
                StatusPanel.SetActive(true);
                StatusLabel.text = "";
                StatusLabel.color = new Color(1f,1f,1f);
                EnableInteraction();
                CoachField.ActivateInputField();
                break;
            case FumbblApi.AuthResult.Authenticating:
                EnsureDelayedSpinner();
                StatusLabel.text = "Logging in…";
                StatusLabel.color = new Color(1f,1f,1f);
                DisableInteraction();
                break;
            case FumbblApi.AuthResult.Authenticated:
                EnsureNoSpinner();
                StatusLabel.text = "Logged in.";
                StatusLabel.color = new Color(1f,1f,1f);
                DisableInteraction();
                SceneManager.LoadScene(NextScene);
                break;
            case FumbblApi.AuthResult.AuthenticationFailed:
                EnsureNoSpinner();
                StatusPanel.SetActive(true);
                StatusLabel.text = "Login failed.";
                StatusLabel.color = new Color(1f,0.8f,0f);
                EnableInteraction();
                CoachField.ActivateInputField();
                break;
            case FumbblApi.AuthResult.ConnectionFailed:
                EnsureNoSpinner();
                StatusPanel.SetActive(true);
                StatusLabel.text = "Connection failed.";
                StatusLabel.color = new Color(1f,0f,0f);
                EnableInteraction();
                break;
        }
    }

    protected virtual void OnNewLoginResult(object source, FumbblApi.LoginResultArgs args)
    {
        switch (args.LoginResult)
        {
            case FumbblApi.LoginResult.LoggingIn:
                EnsureDelayedSpinner();
                StatusLabel.text = "Logging in…";
                StatusLabel.color = new Color(1f,1f,1f);
                DisableInteraction();
                break;
            case FumbblApi.LoginResult.LoginFailed:
                EnsureNoSpinner();
                StatusLabel.text = "Login failed.";
                StatusLabel.color = new Color(1f,0.8f,0f);
                EnableInteraction();
                CoachField.ActivateInputField();
                break;
            case FumbblApi.LoginResult.ConnectionFailed:
                EnsureNoSpinner();
                StatusLabel.text = "Connection failed.";
                StatusLabel.color = new Color(1f,0f,0f);
                EnableInteraction();
                break;
        }
    }

    private IEnumerator SpinnerCoro()
    {
        yield return new WaitForSeconds(1f);
        if (StatusPanel.activeSelf)
        {
            SmallSpinner.SetActive(true);
            ActiveSpinner = SmallSpinner;
        }
        else
        {
            BigSpinner.SetActive(true);
            ActiveSpinner = BigSpinner;
        }
    }

    private async Task<FumbblApi.AuthResult> TryAuth()
    {
        string clientId = PlayerPrefs.GetString("OAuth.ClientId");
        string clientSecret = PlayerPrefs.GetString("OAuth.ClientSecret");
        return await FFB.Instance.Authenticate(clientId, clientSecret);
    }
}
