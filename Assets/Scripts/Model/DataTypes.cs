namespace Fumbbl.Model
{
    public enum BlockDieType
    {
        SKULL,
        BOTH_DOWN,
        PUSHBACK,
        POW_PUSHBACK,
        POW,
        NONE
    }

    static class DataTypes
    {
        public static string GetName(this BlockDieType die)
        {
            switch (die)
            {
                case BlockDieType.SKULL:
                    return "SKULL";
                case BlockDieType.BOTH_DOWN:
                    return "BOTH DOWN";
                case BlockDieType.PUSHBACK:
                    return "PUSHBACK";
                case BlockDieType.POW_PUSHBACK:
                    return "POW/PUSH";
                case BlockDieType.POW:
                    return "POW";
            }
            return null;
        }
    }
}
