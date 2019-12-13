using Fumbbl.Ffb;
using Fumbbl.Ffb.Dto;
using Fumbbl.Ffb.Dto.Reports;
using Fumbbl.Lib;
using Fumbbl.Model;
using Fumbbl.Model.Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        private readonly List<ChatEntry> ChatText;
        public ActionInjectorHandler ActionInjector;

        public Settings Settings;
        public Core Model { get; }
        public string CoachName { get; private set; }

        public delegate void AddReportDelegate(Report text);
        public event AddReportDelegate OnReport;

        public delegate void AddSoundDelegate(string sound);
        public event AddSoundDelegate OnSound;


        public delegate void AddChatDelegate(string coach, ChatSource source, string text);
        public event AddChatDelegate OnChat;

        public int GameId { get; private set; }
        public string PreviousScene { get; internal set; }

	    public Lib.Cache<Sprite> SpriteCache { get; set; }

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
            Model.Clear();
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

        internal List<ChatEntry> GetChat()
        {
            return ChatText;
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
            if (netCommand is Ffb.Dto.Commands.ServerGameState)
            {
                FFB.Instance.Model.Clear();

                var cmd = (Ffb.Dto.Commands.ServerGameState)netCommand;

                Coach homeCoach = new Coach()
                {
                    Name = cmd.game.teamHome.coach,
                    IsHome = true
                };

                Coach awayCoach = new Coach()
                {
                    Name = cmd.game.teamAway.coach,
                    IsHome = false
                };

                Team homeTeam = new Team()
                {
                    Id = cmd.game.teamHome.teamId,
                    Coach = homeCoach,
                    Name = cmd.game.teamHome.teamName,
                    Fame = cmd.game.gameResult.teamResultHome.fame
                };

                Team awayTeam = new Team()
                {
                    Id = cmd.game.teamAway.teamId,
                    Coach = awayCoach,
                    Name = cmd.game.teamAway.teamName,
                    Fame = cmd.game.gameResult.teamResultAway.fame
                };

                FFB.Instance.Model.TeamHome = homeTeam;
                FFB.Instance.Model.TeamAway = awayTeam;

                FFB.Instance.Model.HomePlaying = cmd.game.homePlaying;

                FFB.Instance.Model.HomeCoach = homeCoach;
                FFB.Instance.Model.AwayCoach = awayCoach;

                FFB.Instance.Model.Ball.Coordinate = Coordinate.Create(cmd.game.fieldModel.ballCoordinate);
                FFB.Instance.Model.Ball.InPlay = cmd.game.fieldModel.ballInPlay;
                FFB.Instance.Model.Ball.Moving = cmd.game.fieldModel.ballMoving;

                var positions = new Dictionary<string, Position>();
                var roster = cmd.game.teamHome.roster;
                foreach (var pos in roster.positionArray)
                {
                    positions[pos.positionId] = new Position() {
                        AbstractLabel = pos.shorthand,
                        Name = pos.positionName,
                        IconURL = pos.urlIconSet,
                        PortraitURL = pos.urlPortrait,
                    };
                    if (pos.skillArray != null)
                    {
                        positions[pos.positionId].Skills.AddRange(pos.skillArray.Select(s => s.key));
                    }
                }

                foreach (var p in cmd.game.teamHome.playerArray)
                {
                    Player player = new Player()
                    {
                        Id = p.playerId,
                        Name = p.playerName,
                        Team = homeTeam,
                        Gender = Gender.Male,
                        Position = positions[p.positionId],
                        Movement = p.movement,
                        Strength = p.strength,
                        Agility = p.agility,
                        Armour = p.armour,
                        PortraitURL = p.urlPortrait,

                    };
                    if (p.skillArray != null)
                    {
                        player.Skills.AddRange(p.skillArray.Select(s => s.key));
                    }
                    FFB.Instance.Model.AddPlayer(player);
                }

                foreach (var p in cmd.game.gameResult.teamResultHome.playerResults)
                {
                    var player = FFB.Instance.Model.GetPlayer(p.playerId);
                    player.Spp = p.currentSpps;
                }

                positions.Clear();
                roster = cmd.game.teamAway.roster;
                foreach (var pos in roster.positionArray)
                {
                    positions[pos.positionId] = new Position()
                    {
                        AbstractLabel = pos.shorthand,
                        Name = pos.positionName,
                        IconURL = pos.urlIconSet,
                        PortraitURL = pos.urlPortrait,
                    };
                    if (pos.skillArray != null)
                    {
                        positions[pos.positionId].Skills.AddRange(pos.skillArray.Select(s => s.key));
                    }
                }

                foreach (var p in cmd.game.teamAway.playerArray)
                {
                    Player player = new Player()
                    {
                        Id = p.playerId,
                        Name = p.playerName,
                        Team = awayTeam,
                        Gender = Gender.Male,
                        PositionId = p.positionId,
                        Position = positions[p.positionId],
                        Movement = p.movement,
                        Strength = p.strength,
                        Agility = p.agility,
                        Armour = p.armour,
                        PortraitURL = p.urlPortrait,
                    };
                    if (p.skillArray != null) {
                        player.Skills.AddRange(p.skillArray.Select(s => s.key));
                    }
                    FFB.Instance.Model.AddPlayer(player);
                }

                foreach (var p in cmd.game.gameResult.teamResultAway.playerResults)
                {
                    var player = FFB.Instance.Model.GetPlayer(p.playerId);
                    player.Spp = p.currentSpps;
                }


                foreach (var p in cmd.game.fieldModel.playerDataArray)
                {
                    Player player = FFB.Instance.Model.GetPlayer(p.playerId);
                    player.Coordinate = Coordinate.Create(p.playerCoordinate);
                    player.PlayerState = PlayerState.Get(p.playerState);
                }

                FFB.Instance.Model.Half = cmd.game.half;
                FFB.Instance.Model.TurnHome = cmd.game.turnDataHome.turnNr;
                FFB.Instance.Model.TurnAway = cmd.game.turnDataAway.turnNr;
                FFB.Instance.Model.LastTurnMode = cmd.game.lastTurnMode.As<TurnMode>();
                FFB.Instance.Model.TurnMode = cmd.game.turnMode.As<TurnMode>();

                FFB.Instance.Model.ScoreHome = cmd.game.gameResult.teamResultHome.score;
                FFB.Instance.Model.ScoreAway = cmd.game.gameResult.teamResultAway.score;
            }
            return false;
        }

        internal void ExecuteOnMainThread(Action action)
        {
            ActionInjector.Enqueue(action);
        }

        public void PlaySound(string sound)
        {
            TriggerSoundChanged(sound);
        }

        private void TriggerSoundChanged(string sound)
        {
            OnSound?.Invoke(sound);
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
    }
}
