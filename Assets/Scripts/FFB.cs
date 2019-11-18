using Fumbbl.Dto;
using Fumbbl.Model;
using System;
using System.Collections.Generic;
using UnityEngine;

public class FFB
{
    public static FFB Instance = new FFB();

    private bool Initialized;
    public Networking Network;
    private List<IReport> LogText;
    private List<string> ChatText;

    public Model Model { get; }

    public string CoachName { get; private set; }

    public delegate void AddReportDelegate(IReport text);

    public event AddReportDelegate OnReport;

    public delegate void AddChatDelegate(string text);
    public event AddChatDelegate OnChat;

    public enum LogPanelType
    {
        None,
        Log,
        Chat
    }

    private FFB()
    {
        LogText = new List<IReport>();
        ChatText = new List<string>();
        Network = new Networking();
        Model = new Model();
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

    internal void AddReport(IReport report)
    {
        LogText.Add(report);
        TriggerLogChanged(report);
    }

    internal List<IReport> GetLog()
    {
        return LogText;
    }

    internal List<string> GetChat()
    {
        return ChatText;
    }

    private void TriggerLogChanged(IReport text)
    {
        if (OnReport != null)
        {
            OnReport(text);
        }
    }

    private void TriggerLogRefresh()
    {
        if (OnReport != null)
        {
            foreach (IReport entry in LogText)
            {
                OnReport(entry);
            }
        }
    }

    internal void SetCoachName(string coachName)
    {
        CoachName = coachName;
    }

    internal object GetPlayerName(string actingPlayerId)
    {
        return actingPlayerId;
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
        if (OnReport != null)
        {
            OnChat(text);
        }
    }
    private void TriggerChatRefresh()
    {
        if (OnReport != null)
        {
            foreach (string entry in ChatText)
            {
                OnChat(entry);
            }
        }
    }
}
