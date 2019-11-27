using Fumbbl.Ffb;
using Fumbbl.Ffb.Dto;
using Fumbbl.Ffb.Dto.Reports;
using Fumbbl.Model;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

        public int GameId { get; private set; }
        public string PreviousScene { get; internal set; }

        public Lib.Cache<Texture2D> ImageCache { get; set; }

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

        public void Initialize()
        {
            if (!Initialized)
            {
                Debug.Log("FFB Initialized");
                Initialized = true;
            }
        }

        public async void Connect(int gameId)
        {
            LogText.Clear();
            ChatText.Clear();
            RefreshState();

            GameId = gameId;

            await Network.Connect();
            await Network.StartReceive();

            GameId = 0;
        }

        public void Stop()
        {
            GameId = 0;
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
                var cmd = (Ffb.Dto.Commands.ServerVersion)netCommand;
                AddReport(RawString.Create($"Connected - Server version {cmd.serverVersion}"));
                Network.Spectate(GameId);
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
