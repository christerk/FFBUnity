using Fumbbl.Model.Types;
using System;
using System.Collections.Generic;

namespace Fumbbl.Model
{
    internal class PlayerStore
    {
        public List<Player> Players { get; private set; }
        private Dictionary<string, Player> PlayersById;

        public PlayerStore()
        {
            PlayersById = new Dictionary<string, Player>();
            Players = new List<Player>();
        }

        internal void Clear()
        {
            Players.Clear();
            PlayersById.Clear();
        }

        internal void Add(Player player)
        {
            if (PlayersById.ContainsKey(player.Id))
            {
                Players.Remove(PlayersById[player.Id]);
                PlayersById.Remove(player.Id);
            }
            Players.Add(player);
            PlayersById.Add(player.Id, player);
        }

        internal Player GetPlayer(Coordinate coordinate)
        {
            foreach (var p in Players)
            {
                if (p.Coordinate == coordinate)
                {
                    return p;
                }
            }
            return null;
        }

        internal Player GetPlayer(string playerId)
        {
            if (playerId != null && PlayersById.ContainsKey(playerId))
            {
                return PlayersById[playerId];
            }
            return null;
        }
    }
}