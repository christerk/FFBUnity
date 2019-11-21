using Fumbbl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Model
{
    public static class Util
    {
        public static BlockDieType GetBlockDie(int roll)
        {
            switch (roll)
            {
                case 1: return BlockDieType.SKULL;
                case 2: return BlockDieType.BOTH_DOWN;
                case 5: return BlockDieType.POW_PUSHBACK;
                case 6: return BlockDieType.POW;
                default: return BlockDieType.PUSHBACK;
            }
        }

        public static BlockDieType GetBlockDie(string die)
        {
            switch (die)
            {
                case "SKULL": return BlockDieType.SKULL;
                case "BOTH DOWN": return BlockDieType.BOTH_DOWN;
                case "PUSHBACK": return BlockDieType.PUSHBACK;
                case "POW/PUSH": return BlockDieType.POW_PUSHBACK;
                case "POW": return BlockDieType.POW;
            }
            return BlockDieType.NONE;
        }
    }
}
