using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fumbbl.Model
{
    public class PlayerState
    {
        private static Dictionary<int, PlayerState> PlayerStates = new Dictionary<int, PlayerState>();
        private int State;

        public bool IsUnknown => (State & 0xff) == 0x0000;
        public bool IsStanding => (State & 0xff) == 0x0001;
        public bool IsMoving => (State & 0xff) == 0x0002;
        public bool IsReserve => (State & 0xff) == 0x0009;

        private PlayerState(int state)
        {
            State = state;
        }

        public static PlayerState Get(int? state)
        {
            var key = state ?? 0;
            if (!PlayerStates.ContainsKey(key))
            {
                PlayerStates.Add(key, new PlayerState(key));
            }

            return PlayerStates[key];
        }
    }
}
