using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightHandler : MonoBehaviour
{
    public Camera Camera;
    public GameObject CameraTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Camera.transform.position;
        transform.LookAt(CameraTarget.transform);
    }
}
