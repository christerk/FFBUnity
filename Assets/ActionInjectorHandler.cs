using Fumbbl;
using System;
using System.Collections.Concurrent;
using UnityEngine;

public class ActionInjectorHandler : MonoBehaviour
{
    private ConcurrentQueue<Action> Queue;

    #region MonoBehaviour Methods

    private void Start()
    {
        Queue = new ConcurrentQueue<Action>();

        GameObject[] objs = GameObject.FindGameObjectsWithTag("ActionInjector");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            FFB.Instance.ActionInjector = this;
        }
    }

    private void Update()
    {
        Action action;
        while (Queue.TryDequeue(out action))
        {
            action.Invoke();
        }
    }

    #endregion

    public void Enqueue(Action action)
    {
        Queue.Enqueue(action);
    }
}
