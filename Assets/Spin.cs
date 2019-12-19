using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spin : MonoBehaviour {

    private RectTransform rectComponent;
    private Image imageComp;

    public float Speed = -200f;

    void Start () {
        rectComponent = GetComponent<RectTransform>();
        imageComp = rectComponent.GetComponent<Image>();
    }

	void Update () {
        float z_angles = Speed * Time.deltaTime;
        rectComponent.Rotate(0f, 0f, z_angles);
    }
}
