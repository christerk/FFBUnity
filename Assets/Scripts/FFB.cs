using Fumbbl.Ffb;
using Fumbbl.Ffb.Dto;
using Fumbbl.Ffb.Dto.Reports;
using Fumbbl.Model;
using Fumbbl.Model.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace Fumbbl
{
    public class FFB
    {
        public static FFB Instance = new FFB();

        public Lib.Cache<Sprite> SpriteCache { get; set; }
        public ActionInjectorHandler ActionInjector;
        public Core Model { get; }
        public FumbblApi Api;
        public Networking Network;
        public Settings Settings;
        public delegate void AddChatDelegate(string coach, ChatSource source, string text);
        public delegate void AddReportDelegate(Report text);
        public delegate void AddSoundDelegate(string sound);
        public event AddChatDelegate OnChat;
        public event AddReportDelegate OnReport;
        public event AddSoundDelegate OnSound;
        public int GameId { get; private set; }
        public string CoachName { get; private set; }
        public string PreviousScene { get; internal set; }
        public ReportModeType ReportMode { get; set; }
        public readonly ReflectedFactory<Report, string> ReportFactory;
        public readonly ReflectedFactory<ModelChange, string> ModelChangeFactory;
        private ReflectedFactory<CommandHandler<NetCommand>, Type> CommandFactory { get; }

        public enum ChatSource
        {
            Unknown,
            Home,
            Away,
            Spectator
        }

        public enum LogPanelType
        {
            None,
            Log,
            Chat
        }

        public enum ReportModeType
        {
            Normal,
            Silent
        }

        private bool Initialized;
        private readonly List<ChatEntry> ChatText;
        private readonly List<Report> LogText;

        private FFB()
        {
            Settings = new Settings();
            Settings.Load();
            SpriteCache = new Lib.Cache<Sprite>(url => FumbblApi.GetSpriteAsync(url));
            LogText = new List<Report>();
            ChatText = new List<ChatEntry>();
            Network = new Networking();
            Model = new Core();
            Api = new FumbblApi();
            CommandFactory = new ReflectedFactory<CommandHandler<NetCommand>, Type>();
            ReportFactory = new ReflectedFactory<Report, string>();
            ModelChangeFactory = new ReflectedFactory<ModelChange, string>();
        }

        public async Task<FumbblApi.AuthResult> Authenticate(string clientId, string clientSecret)
        {
            return await Api.Auth(clientId, clientSecret);
        }

        public void Initialize()
        {
            if (!Initialized)
            {
                LogManager.Debug("FFB Initialized");
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

        public void PlaySound(string sound)
        {
            TriggerSoundChanged(sound);
        }

        public void Stop()
        {
            GameId = 0;
            Model.Clear();
            Network.Disconnect();
        }

        internal void AddChatEntry(string coach, string text)
        {
            ChatSource source = ChatSource.Spectator;
            if (string.Equals(FFB.Instance.Model.HomeCoach.Name, coach))
            {
                source = ChatSource.Home;
            }
            if (string.Equals(FFB.Instance.Model.AwayCoach.Name, coach))
            {
                source = ChatSource.Away;
            }

            ChatEntry entry = new ChatEntry(coach, source, text);
            ChatText.Add(entry);
            TriggerChatChanged(entry);
        }

        internal void AddReport(Report report)
        {
            LogText.Add(report);
            TriggerLogChanged(report);
        }

        internal void ExecuteOnMainThread(Action action)
        {
            ActionInjector.Enqueue(action);
        }

        internal List<ChatEntry> GetChat()
        {
            return ChatText;
        }

        internal List<Report> GetLog()
        {
            return LogText;
        }

        internal void HandleNetCommand(NetCommand netCommand)
        {
            var commandHandler = CommandFactory.GetReflectedInstance(netCommand.GetType());
            if (commandHandler != null)
            {
                commandHandler.HandleCommand(netCommand);
            }
            else
            {
                FFB.Instance.AddReport(RawString.Create($"Missing handler for NetCommand {netCommand.GetType().Name}"));
            }
        }

        internal void RefreshState()
        {
            TriggerLogRefresh();
            TriggerChatRefresh();
        }

        internal void SetCoachName(string coachName)
        {
            CoachName = coachName;
        }

        private void TriggerChatChanged(ChatEntry entry)
        {
            OnChat?.Invoke(entry.Coach, entry.Source, entry.Text);
        }

        private void TriggerChatRefresh()
        {
            if (OnChat != null)
            {
                foreach (ChatEntry entry in ChatText)
                {
                    OnChat(entry.Coach, entry.Source, entry.Text);
                }
            }
        }

        private void TriggerLogChanged(Report text)
        {
            try
            {
                OnReport?.Invoke(text);
            }
            catch (Exception e)
            {
                Debug.Log($"Exception during Report Handling: {e.Message}");
                Debug.Log(e.StackTrace);
            }
        }

        private void TriggerLogRefresh()
        {
            if (OnReport != null)
            {
                using (new ContextSwitcher() { ReportMode = ReportModeType.Silent })
                {
                    foreach (Report entry in LogText)
                    {
                        OnReport(entry);
                    }
                }
            }
        }

        private void TriggerSoundChanged(string sound)
        {
            OnSound?.Invoke(sound);
        }
    }
}
