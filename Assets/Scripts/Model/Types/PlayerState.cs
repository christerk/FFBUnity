using System.Collections.Generic;

namespace Fumbbl.Model.Types
{
    public class PlayerState
    {
        public bool IsActive => (State & 0x0100) != 0;

        public bool IsUnknown => (State & 0xff) == 0x0000;
        public bool IsStanding => (State & 0xff) == 0x0001;
        public bool IsMoving => (State & 0xff) == 0x0002;
        public bool IsProne => (State & 0xff) == 0x0003;
        public bool IsStunned => (State & 0xff) == 0x0004;
        public bool IsKnockedOut => (State & 0xff) == 0x0005;
        public bool IsBadlyHurt => (State & 0xff) == 0x0006;
        public bool IsSeriousInjury => (State & 0xff) == 0x0007;
        public bool IsRip => (State & 0xff) == 0x0008;
        public bool IsReserve => (State & 0xff) == 0x0009;
        public bool IsMissing => (State & 0xff) == 0x000a;
        public bool IsFalling => (State & 0xff) == 0x000b;
        public bool IsBlocked => (State & 0xff) == 0x000c;
        public bool IsBanned => (State & 0xff) == 0x000d;
        public bool IsExhausted => (State & 0xff) == 0x000e;
        public bool IsBeingDragged => (State & 0xff) == 0x000f;
        public bool IsPickedUp => (State & 0xff) == 0x0010;
        public bool IsHitByFireball => (State & 0xff) == 0x0011;
        public bool IsHitByLightning => (State & 0xff) == 0x0012;
        public bool IsHitByBomb => (State & 0xff) == 0x0013;

        private static readonly Dictionary<int, PlayerState> PlayerStates = new Dictionary<int, PlayerState>();
        private readonly int State;

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

        public string Description
        {
            get
            {
                switch (State & 0xff)
                {
                    case 0: return "is unknown";
                    case 1: return "is standing";
                    case 2: return "is moving";
                    case 3: return "is prone";
                    case 4: return "has been stunned";
                    case 5: return "has been knocked out";
                    case 6: return "has been badly hurt";
                    case 7: return "has been seriously injured";
                    case 8: return "has been killed";
                    case 9: return "is in reserve";
                    case 10: return "is missing the game";
                    case 11: return "is about to fall down";
                    case 12: return "is being blocked";
                    case 13: return "is banned from the game";
                    case 14: return "is exhausted";
                    case 15: return "is being dragged";
                    case 16: return "has been picked up";
                    default: return null;
                }
            }
        }
    }
}
