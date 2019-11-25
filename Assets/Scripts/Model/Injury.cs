using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fumbbl.Model
{
    public class Injury
    {
        public const int UNKNOWN = 0x0000;
        public const int STANDING = 0x0001;
        public const int MOVING = 0x0002;
        public const int PRONE = 0x0003;
        public const int STUNNED = 0x0004;
        public const int KNOCKED_OUT = 0x0005;
        public const int BADLY_HURT = 0x0006;
        public const int SERIOUS_INJURY = 0x0007;
        public const int RIP = 0x0008;
        public const int RESERVE = 0x0009;
        public const int MISSING = 0x000a;
        public const int FALLING = 0x000b;
        public const int BLOCKED = 0x000c;
        public const int BANNED = 0x000d;
        public const int EXHAUSTED = 0x000e;
        public const int BEING_DRAGGED = 0x000f;
        public const int PICKED_UP = 0x0010;
        public const int HIT_BY_FIREBALL = 0x0011;  // used for bloodSpots only
        public const int HIT_BY_LIGHTNING = 0x0012;  // used for bloodSpots only  
        public const int HIT_BY_BOMB = 0x0013;  // used for bloodSpots only

        internal static string GetDescription(int? playerState)
        {
            switch(playerState & 0xff)
            {
                case UNKNOWN: return "is unknown";
                case STANDING: return "is standing";
                case MOVING: return "is moving";
                case PRONE: return "is prone";
                case STUNNED: return "has been stunned";
                case KNOCKED_OUT: return "has been knocked out";
                case BADLY_HURT: return "has been badly hurt";
                case SERIOUS_INJURY: return "has been seriously injured";
                case RIP: return "has been killed";
                case RESERVE: return "is in reserve";
                case MISSING: return "is missing the game";
                case FALLING: return "is about to fall down";
                case BLOCKED: return "is being blocked";
                case BANNED: return "is banned from the game";
                case EXHAUSTED: return "is exhausted";
                case BEING_DRAGGED: return "is being dragged";
                case PICKED_UP: return "has been picked up";
                default: return null;
            }
        }
    }
}
