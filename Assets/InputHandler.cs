using Fumbbl;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputHandler : MonoBehaviour
{
    public Camera Camera;

    public float mouseSensitivity = 1.0f;
    private Vector3 lastPosition;

    void Start()
    {

    }

    void Update()
    {
        if (Camera != null)
        {
            if (Input.GetKeyDown(KeyCode.Home))
            {
                Camera.transform.position = new Vector3(0, 0, -10);
            }
            if (Input.GetMouseButtonDown(2))
            {
                lastPosition = Input.mousePosition;
            }

            if (Input.GetMouseButton(2))
            {
                Vector3 delta = Input.mousePosition - lastPosition;
                Camera.transform.Translate(-delta.x * mouseSensitivity, -delta.y * mouseSensitivity, 0);
                lastPosition = Input.mousePosition;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            string currentScene = SceneManager.GetActiveScene().name;
            if (string.Equals("SettingsScene", currentScene))
            {
                SwitchToPreviousScene();
            }
            else
            {
                FFB.Instance.PreviousScene = currentScene;
                SwitchToSettingsScene();
            }
        }
    }

    public void SwitchToPreviousScene()
    {
        MainHandler.Instance.SetScene(FFB.Instance.PreviousScene);
    }

    public void SwitchToSettingsScene()
    {
        MainHandler.Instance.SetScene(MainHandler.SceneType.SettingsScene);
    }
}
