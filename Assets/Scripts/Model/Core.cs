using Fumbbl.Ffb.Dto.ModelChanges;
using Fumbbl.Model.Types;
using Fumbbl.View;
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

        private PlayerStore PlayerStore;
        private ReflectedFactory<ModelUpdater<Ffb.Dto.ModelChange>, Type> ModelChangeFactory { get; }

        private SquareInformation SquareInformation;

        public Core()
        {
            //ModelChangeFactory = new ModelChangeFactory();
            ModelChangeFactory = new ReflectedFactory<ModelUpdater<Ffb.Dto.ModelChange>, Type>();
            ActingPlayer = new ActingPlayer();
            PlayerStore = new PlayerStore();
            Ball = new Ball();
            BlockDice = new List<View.BlockDie>();
            Positions = new Dictionary<string, Position>();
            SquareInformation = new SquareInformation(26, 15);
        }

        internal List<Types.TrackNumber> TrackNumbers => SquareInformation.TrackNumbers;
        internal List<Types.PushbackSquare> PushbackSquares => SquareInformation.PushbackSquares;
        internal List<Types.Player> Players => PlayerStore.Players;

        public void Clear()
        {
            LogManager.Debug("Clearing Model");
            PlayerStore.Clear();
            ActingPlayer.Clear();
            BlockDice.Clear();
            SquareInformation.Clear();
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
                BlockDice.Add(new View.BlockDie(index, Types.BlockDie.Get(roll)));
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
            PlayerStore.Add(player);
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

        internal void Add(Types.PushbackSquare square)
        {
            SquareInformation.Add(square);
        }

        internal void Add(Types.TrackNumber trackNumber)
        {
            SquareInformation.Add(trackNumber);
        }

        internal void Add(Types.MoveSquare moveSquare)
        {
            SquareInformation.Add(moveSquare);
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
            return PlayerStore.GetPlayer(playerId);
        }

        internal Position GetPosition(string positionId)
        {
            if (positionId == null)
            {
                return null;
            }
            return Positions[positionId];
        }
        internal Player GetPlayer(Coordinate coordinate)
        {
            return PlayerStore.GetPlayer(coordinate);
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

        internal void RemovePushbackSquare(Types.PushbackSquare square)
        {
            SquareInformation.Remove(square);
        }

        internal void RemoveTrackNumber(Types.TrackNumber trackNumber)
        {
            SquareInformation.Remove(trackNumber);
        }

        internal void RemoveMoveSquare(Types.MoveSquare moveSquare)
        {
            SquareInformation.Remove(moveSquare);
        }

    }
}
