using System.Collections.Generic;

namespace Fumbbl.Model.Types
{
    public class BlockDie
    {
        public enum DieType
        {
            None,
            Skull,
            BothDown,
            Pushback,
            PowPush,
            Pow
        }

        public string Name { get; private set; }
        public DieType Type { get; private set; }

        public static BlockDie Skull = new BlockDie() { Name = "SKULL", Type = DieType.Skull };
        public static BlockDie BothDown = new BlockDie() { Name = "BOTH DOWN", Type = DieType.BothDown };
        public static BlockDie Pushback = new BlockDie() { Name = "PUSHBACK", Type = DieType.Pushback };
        public static BlockDie PowPushback = new BlockDie() { Name = "POW/PUSH", Type = DieType.PowPush };
        public static BlockDie Pow = new BlockDie() { Name = "POW", Type = DieType.Pow };

        public static BlockDie None = new BlockDie() { Name = "None", Type = DieType.None };

        internal static BlockDie Get(int roll)
        {
            switch (roll)
            {
                case 0: return None;
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
