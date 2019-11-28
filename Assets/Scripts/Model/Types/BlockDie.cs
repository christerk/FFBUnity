using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fumbbl.Model.Types
{
    public class BlockDie
    {
        public string Name { get; private set; }

        public static BlockDie Skull = new BlockDie() { Name = "SKULL" };
        public static BlockDie BothDown = new BlockDie() { Name = "BOTH DOWN" };
        public static BlockDie Pushback = new BlockDie() { Name = "PUSHBACK" };
        public static BlockDie PowPushback = new BlockDie() { Name = "POW/PUSH" };
        public static BlockDie Pow = new BlockDie() { Name = "POW" };

        internal static BlockDie Get(int roll)
        {
            switch (roll)
            {
                case 1: return Skull;
                case 2: return BothDown;
                case 5: return PowPushback;
                case 6: return Pow;
                default: return Pushback;
            }
        }
    }

    public static class BlockDieExtensions
    {
        private static readonly Dictionary<string, BlockDie> BlockDice = new Dictionary<string, BlockDie>();

        static BlockDieExtensions()
        {
            BlockDice = new Dictionary<string, BlockDie>()
            {
                ["SKULL"] = BlockDie.Skull,
                ["BOTH DOWN"] = BlockDie.BothDown,
                ["PUSHBACK"] = BlockDie.Pushback,
                ["POW/PUSH"] = BlockDie.PowPushback,
                ["POW"] = BlockDie.Pow
            };
        }

        public static BlockDie AsBlockDie(this FFBEnumeration ffbEnum)
        {
            return BlockDice.ContainsKey(ffbEnum.key) ? BlockDice[ffbEnum.key] : null;
        }
    }
}
