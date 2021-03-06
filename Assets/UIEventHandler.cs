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
    private ScrollView chatScroll;

    // Start is called before the first frame update
    void Start()
    {
        LogTextFactory = new ReflectedFactory<LogTextGenerator<Report>, Type>();
        FFB.Instance.OnReport += AddReport;
        FFB.Instance.OnChat += AddChat;

        var root = GetComponent<UIDocument>().rootVisualElement;

        logScroll = root.Q<ScrollView>("logScroll");
        chatScroll = root.Q<ScrollView>("chatScroll");

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
        string colour;
        switch (source)
        {
            case ChatSource.Home: colour = "#ff0000"; break;
            case ChatSource.Away: colour = "#0000ff"; break;
            default: colour = "#336633"; break;
        }
        string line = $"<<{colour}>{TextPanelHandler.SanitizeText(coach)}</color>> {TextPanelHandler.SanitizeText(text)}";
        AddChatText(line);
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

    private void AddChatText(string text)
    {
        if (text != null)
        {
            Label label = new Label();
            label.text = text;
            label.style.fontSize = 10;
            label.style.whiteSpace = WhiteSpace.Normal;
            chatScroll.Add(label);
            Invoke("ScrollChatToBottom", 0.05f);
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
            label.style.whiteSpace = WhiteSpace.Normal;
            logScroll.Add(label);
            Invoke("ScrollLogToBottom", 0.05f);
        }
    }

    private void ScrollLogToBottom()
    {
        var bottom = logScroll.contentContainer.localBound.height;
        logScroll.scrollOffset = new Vector2(0f, bottom);
    }
    private void ScrollChatToBottom()
    {
        var bottom = chatScroll.contentContainer.localBound.height;
        chatScroll.scrollOffset = new Vector2(0f, bottom);
    }
}
