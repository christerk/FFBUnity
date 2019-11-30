using Fumbbl.Model.Types;
using System;
using System.Collections.Generic;

namespace Fumbbl.Model
{
    public class Core
    {
        //private ModelChangeFactory ModelChangeFactory { get; }
        private ReflectedFactory<ModelUpdater, Type> ModelChangeFactory { get; }
        public ActingPlayer ActingPlayer { get; set; }
        private Dictionary<string, Player> Players { get; set; }

        public Core()
        {
            //ModelChangeFactory = new ModelChangeFactory();
            ModelChangeFactory = new ReflectedFactory<ModelUpdater, Type>();
            ActingPlayer = new ActingPlayer();
            Players = new Dictionary<string, Player>();
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
            ModelUpdater updater = ModelChangeFactory.GetReflectedInstance(change.GetType());
            updater?.Apply(change);
        }

        internal Player GetPlayer(string playerId)
        {
            if (playerId == null)
            {
                return null;
            }
            if (!Players.ContainsKey(playerId))
            {
                Players.Add(playerId, new Player() {
                    Id = playerId,
                    Name = playerId,
                    Gender = Gender.Male
                });
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