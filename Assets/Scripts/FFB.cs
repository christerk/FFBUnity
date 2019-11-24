using Fumbbl.Ffb;
using Fumbbl.Ffb.Dto;
using Fumbbl.Model;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Fumbbl
{
    public class FFB
    {
        public static FFB Instance = new FFB();

        private bool Initialized;
        public FumbblApi Api;
        public Networking Network;
        private readonly List<Report> LogText;
        private readonly List<string> ChatText;

        public Core Model { get; }

        public string CoachName { get; private set; }

        public delegate void AddReportDelegate(Report text);

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
            LogText = new List<Report>();
            ChatText = new List<string>();
            Network = new Networking();
            Model = new Core();
            Api = new FumbblApi();
        }

        public bool Authenticate(string clientId, string clientSecret)
        {
            return Api.Auth(clientId, clientSecret);
        }

        public async void Initialize()
        {
            if (!Initialized)
            {
                Debug.Log("FFB Initialized");
                Initialized = true;
                await Network.Connect();
            }
        }

        public void Stop()
        {
            Network.Disconnect();
        }

        internal void AddReport(Report report)
        {
            LogText.Add(report);
            TriggerLogChanged(report);
        }

        internal List<Report> GetLog()
        {
            return LogText;
        }

        internal List<string> GetChat()
        {
            return ChatText;
        }

        private void TriggerLogChanged(Report text)
        {
            OnReport?.Invoke(text);
        }

        private void TriggerLogRefresh()
        {
            if (OnReport != null)
            {
                foreach (Report entry in LogText)
                {
                    OnReport(entry);
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

        internal bool HandleNetCommand(NetCommand netCommand)
        {
            if (netCommand is Ffb.Dto.Commands.ServerVersion)
            {
                Network.Spectate(1201202);
                return true;
            }
            if (netCommand is Ffb.Dto.Commands.ServerTalk)
            {
                var cmd = (Ffb.Dto.Commands.ServerTalk)netCommand;
                foreach (var talk in cmd.talks)
                {
                    AddChatEntry(cmd.coach, talk);
                }
                return true;
            }
            if (netCommand is Ffb.Dto.Commands.ServerSound)
            {
                PlaySound(((Ffb.Dto.Commands.ServerSound)netCommand).sound);
            }
            return false;
        }

        private void PlaySound(string sound)
        {
            Debug.Log($"Play Sound {sound}");
        }

        internal void AddChatEntry(string coach, string text)
        {
            string line = $"<noparse><</noparse>{TextPanelHandler.SanitizeText(coach)}> {TextPanelHandler.SanitizeText(text)}";

            ChatText.Add(line);
            TriggerChatChanged(line);
        }

        private void TriggerChatChanged(string text)
        {
            OnChat?.Invoke(text);
        }
        private void TriggerChatRefresh()
        {
            if (OnChat != null)
            {
                foreach (string entry in ChatText)
                {
                    OnChat(entry);
                }
            }
        }
    }
}