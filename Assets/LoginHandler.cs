using Fumbbl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginHandler : MonoBehaviour
{
    public GameObject LoginPanel;
    public GameObject ConnectingLabel;
    public string NextScene;

    // Start is called before the first frame update
    void Start()
    {
        string clientId = PlayerPrefs.GetString("OAuth.ClientId");
        string clientSecret = PlayerPrefs.GetString("OAuth.ClientSecret");
        bool rememberLogin = PlayerPrefs.GetInt("Login.Remember") == 1;

        bool authenticated = false;

        if (clientId != null)
        {
            LoginPanel.SetActive(false);
            ConnectingLabel.SetActive(true);

            authenticated = FFB.Instance.Authenticate(clientId, clientSecret);

            SceneManager.LoadScene(NextScene);
        }

        if (!authenticated)
        {
            LoginPanel.SetActive(true);
            ConnectingLabel.SetActive(false);
        }
    }
}
