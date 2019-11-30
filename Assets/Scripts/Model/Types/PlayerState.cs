using System.Collections.Generic;

namespace Fumbbl.Model.Types
{
    public class PlayerState
    {
        private static readonly Dictionary<int, PlayerState> PlayerStates = new Dictionary<int, PlayerState>();
        private readonly int State;

        public bool IsUnknown => (State & 0xff) == 0x0000;
        public bool IsStanding => (State & 0xff) == 0x0001;
        public bool IsMoving => (State & 0xff) == 0x0002;
        public bool IsProne => (State & 0xff) == 0x0003;
        public bool IsStunned => (State & 0xff) == 0x0004;
        public bool IsKnockedOut => (State & 0xff) == 0x0005;

        public bool IsBeingDragged => (State & 0xff) == 0x000f;
        public bool IsReserve => (State & 0xff) == 0x0009;

        public bool IsActive => (State & 0x0100) != 0;

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
