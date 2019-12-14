using System.Collections.Generic;

namespace Fumbbl.Model.Types
{
    public class BlockDie : FfbEnumerationFactory
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

        public DieType Type;

        public BlockDie(string name) : base(name) { }

        public static BlockDie Skull = new BlockDie("SKULL") { Type = DieType.Skull };
        public static BlockDie BothDown = new BlockDie("BOTH DOWN") { Type = DieType.BothDown };
        public static BlockDie Pushback = new BlockDie("PUSHBACK") { Type = DieType.Pushback };
        public static BlockDie PowPushback = new BlockDie("POW/PUSH") { Type = DieType.PowPush };
        public static BlockDie Pow = new BlockDie("POW") { Type = DieType.Pow };

        public static BlockDie None = new BlockDie("None") { Type = DieType.None };

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
}
