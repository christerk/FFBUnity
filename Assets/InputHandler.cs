using Fumbbl;
using UnityEngine;
public class InputHandler : MonoBehaviour
{
    public Camera Camera;

    public float mouseSensitivity = 1.0f;
    private Vector3 lastPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MainHandler.Instance.SetScene(MainHandler.SceneType.SettingsScene);
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            MainHandler.Instance.SetScene(MainHandler.SceneType.GameBrowserScene);
        }
    }
}
