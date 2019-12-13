using Fumbbl;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputHandler : MonoBehaviour
{
    private Vector3 lastPosition;

    public Camera Camera;
    public float mouseSensitivity = 1.0f;

    #region MonoBehaviour Methods

    private void Update()
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

            if (Input.mouseScrollDelta.y != 0)
            {
                Camera.orthographicSize += Input.mouseScrollDelta.y * 45;
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
                SwitchToSettingsScene();
            }
        }
    }
    #endregion

    #region Custom Methods

    public void SwitchToPreviousScene()
    {
        MainHandler.Instance.SetScene(FFB.Instance.PreviousScene);
    }

    public void SwitchToSettingsScene()
    {
        FFB.Instance.PreviousScene = SceneManager.GetActiveScene().name;
        MainHandler.Instance.SetScene(MainHandler.SceneType.SettingsScene);
    }
    #endregion
}
