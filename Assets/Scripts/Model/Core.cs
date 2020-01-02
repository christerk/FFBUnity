﻿using Fumbbl.Ffb.Dto.ModelChanges;
using Fumbbl.Model.Types;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Fumbbl.Model
{
    public class Core
    {
        public ActingPlayer ActingPlayer { get; set; }
        public string DefenderId { get; internal set; }
        public Ball Ball;
        public Coach AwayCoach { get; internal set; }
        public Coach HomeCoach { get; internal set; }
        public Coordinate PassCoordinate { get; internal set; }
        public Dictionary<int, View.PushbackSquare> PushbackSquares;
        public Dictionary<int, View.TrackNumber> TrackNumbers;
        public List<View.BlockDie> BlockDice;
        public Team TeamAway { get; internal set; }
        public Team TeamHome { get; internal set; }
        public Dictionary<string, Position> Positions { get; internal set; }
        public TurnMode TurnMode { get; set; }
        public bool HomePlaying { get; internal set; }
        public int BlockDieIndex;
        public int Half { get; internal set; }
        public int ScoreAway { get; internal set; }
        public int ScoreHome { get; internal set; }
        public int TurnAway { get; internal set; }
        public int TurnHome { get; internal set; }

        private Dictionary<string, Player> Players { get; set; }
        private ReflectedFactory<ModelUpdater<Ffb.Dto.ModelChange>, Type> ModelChangeFactory { get; }
        public Core()
        {
            //ModelChangeFactory = new ModelChangeFactory();
            ModelChangeFactory = new ReflectedFactory<ModelUpdater<Ffb.Dto.ModelChange>, Type>();
            ActingPlayer = new ActingPlayer();
            Players = new Dictionary<string, Player>();
            Ball = new Ball();
            PushbackSquares = new Dictionary<int, View.PushbackSquare>();
            TrackNumbers = new Dictionary<int, View.TrackNumber>();
            BlockDice = new List<View.BlockDie>();
            Positions = new Dictionary<string, Position>();
        }

        public void Clear()
        {
            Debug.Log("Clearing Model");
            Players.Clear();
            ActingPlayer.Clear();
            PushbackSquares.Clear();
            TrackNumbers.Clear();
            BlockDice.Clear();
        }

        public void AddBlockDie(int roll)
        {
            if (roll > 0)
            {
                if (BlockDice.Count > 0 && BlockDice[BlockDice.Count-1].Active == false)
                {
                    BlockDice.Clear();
                }
                int index = BlockDieIndex++;
                BlockDice.Add(new View.BlockDie(index, BlockDie.Get(roll)));
            }
            else
            {
                foreach (var die in BlockDice)
                {
                    die.Active = false;
                }
            }
        }

        internal void Add(Player player)
        {
            if (Players.ContainsKey(player.Id))
            {
                Players[player.Id] = player;
            }
            else
            {
                Players.Add(player.Id, player);
            }
        }

        internal void Add(Position position)
        {
            if (Positions.ContainsKey(position.Id))
            {
                Positions[position.Id] = position;
            }
            else
            {
                Positions.Add(position.Id, position);
            }
        }

        internal void Add(PushbackSquare square)
        {
            int key = square.coordinate[0] * 100 + square.coordinate[1];
            if (!PushbackSquares.ContainsKey(key))
            {
                PushbackSquares.Add(key, new View.PushbackSquare(square));
            }
            else
            {
                PushbackSquares[key].Refresh(new View.PushbackSquare(square));
            }
        }

        internal void Add(TrackNumber square)
        {
            int key = square.coordinate[0] * 100 + square.coordinate[1];
            if (!TrackNumbers.ContainsKey(key))
            {
                TrackNumbers.Add(key, new View.TrackNumber(square));
            }
            else
            {
                TrackNumbers[key].Refresh(new View.TrackNumber(square));
            }
        }

        internal void ApplyChange(Ffb.Dto.ModelChange change)
        {
            ModelUpdater<Ffb.Dto.ModelChange> updater = ModelChangeFactory.GetReflectedInstance(change.GetType());
            if (updater != null)
            {
                updater.Apply(change);
            }
            else
            {
                LogManager.Info($"Missing handler for ModelChange {change.GetType().Name}");
            }
        }

        internal Player GetPlayer(string playerId)
        {
            if (playerId == null)
            {
                return null;
            }
            return Players[playerId];
        }

        internal Position GetPosition(string positionId)
        {
            if (positionId == null)
            {
                return null;
            }
            return Positions[positionId];
        }
        internal Player GetPlayer(Coordinate coord)
        {
            foreach (Player p in Players.Values)
            {
                if (p.Coordinate.Equals(coord))
                {
                    return p;
                }
            }
            return null;
        }

        internal IEnumerable<Player> GetPlayers()
        {
            return Players.Values;
        }

        internal Team GetTeam(string teamId)
        {
            if (string.Equals(teamId, TeamHome.Id))
            {
                return TeamHome;
            }
            else
            {
                return TeamAway;
            }
        }

        internal void RemovePushbackSquare(PushbackSquare square)
        {
            int key = square.coordinate[0] * 100 + square.coordinate[1];
            PushbackSquares.Remove(key);
        }

        internal void RemoveTrackNumber(TrackNumber square)
        {
            int key = square.coordinate[0] * 100 + square.coordinate[1];
            TrackNumbers.Remove(key);
        }
    }
}
