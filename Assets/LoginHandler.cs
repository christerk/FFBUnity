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

    private static bool seriousauth;
    private static IEnumerator authenticatingUIcoro;

    #region MonoBehaviour Methods

    // Start is called before the first frame update
    private async void Start()
    {
        // The scene is assumed to prohibit interactions at this point.
        // Start is a special case as we try to get authenticated immediately
        // with the stored credentials.
        seriousauth = false;

        // Setup the input fields.
        CoachField.onSubmit.AddListener(v => { PasswordField.ActivateInputField(); });
        PasswordField.onSubmit.AddListener(v => { Login(); });

        // We subscribed for the Auth events to make the UI update with the
        // result of this authentication attempt.
        FFB.Instance.Authenticating += OnAuthenticating;
        FFB.Instance.Authenticated += OnAuthenticated;
        FFB.Instance.ConnectionFailed += OnConnectionFailed;
        FFB.Instance.AuthenticationFailed += OnAuthenticationFailed;

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

    private void EnsureStoppedOnAuthenticatingUICoroutine()
    {
        if (authenticatingUIcoro != null)
        {
            StopCoroutine(authenticatingUIcoro);
            authenticatingUIcoro = null;
        }
    }

    public async void Login()
    {
        OnAuthenticating();

        FumbblApi.LoginResult loginresult = await FFB.Instance.Api.Login(CoachField.text, PasswordField.text);

        switch (loginresult)
        {
            case FumbblApi.LoginResult.Authenticated:
                await TryAuth();
                // ^We are subscribed to the events it will publish.
                break;
            case FumbblApi.LoginResult.AuthenticationFailed:
                OnAuthenticationFailed();
                break;
            case FumbblApi.LoginResult.ConnectionFailed:
                OnConnectionFailed();
                break;
        }
    }

    private void OnAuthenticating()
    {
        EnsureStoppedOnAuthenticatingUICoroutine();
        StatusLabel.text = "Logging in...";
        StatusLabel.color = new Color(1f,1f,1f);
        DisableInteraction();
        authenticatingUIcoro = OnAuthenticatingUICoroutine();
        StartCoroutine(authenticatingUIcoro);
    }

    private IEnumerator OnAuthenticatingUICoroutine()
    {
        int ndots = 3;
        string sdots;
        while (true)
        {
            sdots = new String('.', ndots);
            StatusLabel.text = $"Logging in{sdots}";
            ndots = (++ndots - 2) % 2 + 2;
            yield return new WaitForSeconds(1f);
        }
    }

    private async void OnAuthenticated()
    {
        EnsureStoppedOnAuthenticatingUICoroutine();
        StatusLabel.text = "Logged in.";
        StatusLabel.color = new Color(1f,1f,1f);
        DisableInteraction();
        await Task.Delay(1000);
        SceneManager.LoadScene(NextScene);

    }

    private void OnAuthenticationFailed()
    {
        EnsureStoppedOnAuthenticatingUICoroutine();
        if (seriousauth)
        {
            StatusLabel.text = "Login failed.";
            StatusLabel.color = new Color(1f,0.8f,0f);
        }
        else
        {
            OnNormalInput();
            seriousauth = true;
        }
        EnableInteraction();
        CoachField.ActivateInputField();
    }

    private void OnConnectionFailed()
    {
        EnsureStoppedOnAuthenticatingUICoroutine();
        StatusLabel.text = "Connection failed.";
        StatusLabel.color = new Color(1f,0f,0f);
        EnableInteraction();
    }

    private void OnNormalInput()
    {
        EnsureStoppedOnAuthenticatingUICoroutine();
        StatusLabel.text = "";
        StatusLabel.color = new Color(1f,1f,1f);
        EnableInteraction();
    }

    private async Task TryAuth()
    {
        string clientId = PlayerPrefs.GetString("OAuth.ClientId");
        string clientSecret = PlayerPrefs.GetString("OAuth.ClientSecret");
        await FFB.Instance.Authenticate(clientId, clientSecret);
    }
}
