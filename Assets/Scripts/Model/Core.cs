using Fumbbl.Model.Types;
using System;
using System.Collections.Generic;

namespace Fumbbl.Model
{
    public class Core
    {
        //private ModelChangeFactory ModelChangeFactory { get; }
        private ReflectedFactory<ModelUpdater<Ffb.Dto.ModelChange>, Type> ModelChangeFactory { get; }
        public ActingPlayer ActingPlayer { get; set; }
        private Dictionary<string, Player> Players { get; set; }
        public Coach HomeCoach { get; internal set; }
        public Coach AwayCoach { get; internal set; }

        public Ball Ball;

        public Core()
        {
            //ModelChangeFactory = new ModelChangeFactory();
            ModelChangeFactory = new ReflectedFactory<ModelUpdater<Ffb.Dto.ModelChange>, Type>();
            ActingPlayer = new ActingPlayer();
            Players = new Dictionary<string, Player>();
            Ball = new Ball();
        }

        public void Clear()
        {
            Players.Clear();
            ActingPlayer.Clear();
        }

        internal IEnumerable<Player> GetPlayers()
        {
            return Players.Values;
        }

        internal void ApplyChange(Ffb.Dto.ModelChange change)
        {
            //IModelUpdater updater = ModelChangeFactory.Create(change);
            ModelUpdater<Ffb.Dto.ModelChange> updater = ModelChangeFactory.GetReflectedInstance(change.GetType());
            updater?.Apply(change);
        }

        internal Player GetPlayer(string playerId)
        {
            if (playerId == null)
            {
                return null;
            }
            return Players[playerId];
        }

        internal void AddPlayer(Player player)
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
    }
}