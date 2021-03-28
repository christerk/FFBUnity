using Fumbbl;
using Fumbbl.Ffb.Dto;
using Fumbbl.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static Fumbbl.FFB;

public class UIEventHandler : MonoBehaviour
{
    private ReflectedFactory<LogTextGenerator<Report>, Type> LogTextFactory;
    private ScrollView logScroll;

    // Start is called before the first frame update
    void Start()
    {
        LogTextFactory = new ReflectedFactory<LogTextGenerator<Report>, Type>();
        FFB.Instance.OnReport += AddReport;
        FFB.Instance.OnChat += AddChat;

        var root = GetComponent<UIDocument>().rootVisualElement;

        logScroll = root.Q<ScrollView>("logScroll");

    }

    private void OnDisable()
    {
        FFB.Instance.OnChat -= AddChat;
        FFB.Instance.OnReport -= AddReport;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void AddChat(string coach, ChatSource source, string text)
    {

    }

    private void AddReport(Report report)
    {
        var handler = LogTextFactory.GetReflectedInstance(report.GetType());
        if (handler != null)
        {
            foreach (var logRecord in handler.HandleReport(report))
            {
                AddLogText(logRecord.Text, logRecord.Indent);
            }
        }
        else
        {
            AddLogText($"<b>* * * Unhandled report {report.GetType().Name} * * *</b>", 0);
        }
    }


    private void AddLogText(string text, int indent)
    {
        if (text != null)
        {
            Label label = new Label();
            label.style.marginLeft = indent * 10;
            label.text = text;
            label.style.fontSize = 10;
            logScroll.Add(label);
            //Invoke("ScrollToBottom", 0.1f);
            logScroll.scrollOffset = new Vector2(0f, 1f);
        }
    }

}
