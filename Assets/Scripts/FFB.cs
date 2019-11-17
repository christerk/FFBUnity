using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class FFB
{
    public static FFB Instance = new FFB();

    private bool Initialized;
    public Networking Network;
    private List<string> LogText;
    private List<string> ChatText;

    public string CoachName { get; private set; }

    public delegate void AddText(LogPanelType type, string text);
    public event AddText OnText;

    public enum LogPanelType
    {
        None,
        Log,
        Chat
    }

    private FFB()
    {
        LogText = new List<string>();
        ChatText = new List<string>();
        Network = new Networking();
    }

    public async void Initialize()
    {
        if (!Initialized)
        {
            Initialized = true;
            Debug.Log(LogText.ToString());
            await Network.Connect();
        }
    }

    public void Stop()
    {
        Network.Disconnect();
    }

    internal void AddLogEntry(string text)
    {
        LogText.Add(text);
        TriggerLogChanged(text);
    }

    internal List<string> GetLog()
    {
        return LogText;
    }

    internal List<string> GetChat()
    {
        return ChatText;
    }

    private void TriggerLogChanged(string text)
    {
        if (OnText != null)
        {
            OnText(LogPanelType.Log, text);
        }
    }

    private void TriggerLogRefresh()
    {
        if (OnText != null)
        {
            foreach (string entry in LogText)
            {
                OnText(LogPanelType.Log, entry);
            }
        }
    }

    internal void SetCoachName(string coachName)
    {
        CoachName = coachName;
    }

    internal void RefreshState()
    {
        TriggerLogRefresh();
        TriggerChatRefresh();
    }

    internal void AddChatEntry(string coach, string text)
    {
        string line = $"<noparse><</noparse>{TextPanelHandler.SanitizeText(coach)}> {TextPanelHandler.SanitizeText(text)}";

        ChatText.Add(line);
        TriggerChatChanged(line);
    }

    private void TriggerChatChanged(string text)
    {
        if (OnText != null)
        {
            OnText(LogPanelType.Chat, text);
        }
    }
    private void TriggerChatRefresh()
    {
        if (OnText != null)
        {
            foreach (string entry in ChatText)
            {
                OnText(LogPanelType.Chat, entry);
            }
        }
    }

}
