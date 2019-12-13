using Fumbbl;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginHandler : MonoBehaviour
{
    public GameObject ConnectingLabel;
    public GameObject LoginPanel;
    public TMPro.TMP_InputField CoachField;
    public TMPro.TMP_InputField PasswordField;
    public string NextScene;

    #region MonoBehaviour Methods

    // Start is called before the first frame update
    private void Start()
    {
        TryLogin();

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

    private void Login()
    {
        bool success = FFB.Instance.Api.Login(CoachField.text, PasswordField.text);

        if (success)
        {
            TryLogin();
        }
        else
        {
            CoachField.ActivateInputField();
        }
    }

    private void TryLogin()
    {
        string clientId = PlayerPrefs.GetString("OAuth.ClientId");
        string clientSecret = PlayerPrefs.GetString("OAuth.ClientSecret");

        LoginPanel.SetActive(false);
        ConnectingLabel.SetActive(true);
        bool authenticated = FFB.Instance.Authenticate(clientId, clientSecret);

        if (authenticated)
        {
            SceneManager.LoadScene(NextScene);
        }
        else
        {
            LoginPanel.SetActive(true);
            ConnectingLabel.SetActive(false);
        }
    }
}
