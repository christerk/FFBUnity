using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class InputHandler : MonoBehaviour
{
    public Camera camera;

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
            camera.transform.position = new Vector3(0, 0, -10);
        }
        if (Input.GetMouseButtonDown(2))
        {
            lastPosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(2))
        {
            Vector3 delta  = Input.mousePosition - lastPosition;
            camera.transform.Translate(-delta.x * mouseSensitivity, -delta.y * mouseSensitivity, 0);
            lastPosition = Input.mousePosition;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MainHandler.Instance.SetScene(MainHandler.SceneType.SettingsScene);
        }
    }
}
