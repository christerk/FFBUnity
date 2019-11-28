using Fumbbl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActingPlayerHandler : MonoBehaviour
{
    private GameObject Outline;
    void Start()
    {
        Outline = this.transform.GetChild(1).gameObject;
    }

    void Update()
    {
        bool active = string.Equals(FFB.Instance.Model.ActingPlayer.PlayerId, name);
        Outline.SetActive(active);
    }
}
