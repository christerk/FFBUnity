using Fumbbl;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginHandler : MonoBehaviour
{
    public GameObject LoginPanel;
    public GameObject ConnectingLabel;
    public string NextScene;
    public TMPro.TMP_InputField CoachField;
    public TMPro.TMP_InputField PasswordField;

    // Start is called before the first frame update
    void Start()
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

    void Login()
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
}
