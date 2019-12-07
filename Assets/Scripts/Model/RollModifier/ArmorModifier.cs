namespace Fumbbl.Model.RollModifier
{
    public class ArmorModifier : AbstractModifier
    {
        public ArmorModifier(string name, int modifier) : base(name, modifier) { 
            SignMode = SignMode.Negative;
        }

        public static ArmorModifier Claws = new ArmorModifier("Claws", 0) { SignMode = SignMode.Hidden, ShowModifier = false, ShowName = false };
        public static ArmorModifier MightyBlow = new ArmorModifier("Mighty Blow", 1) { };
        public static ArmorModifier OffensiveAssist1 = new ArmorModifier("1 Offensive Assist", 1) { ShowModifier = false };
        public static ArmorModifier OffensiveAssist2 = new ArmorModifier("2 Offensive Assists", 2) { ShowModifier = false };
        public static ArmorModifier OffensiveAssist3 = new ArmorModifier("3 Offensive Assists", 3) { ShowModifier = false };
        public static ArmorModifier OffensiveAssist4 = new ArmorModifier("4 Offensive Assists", 4) { ShowModifier = false };
        public static ArmorModifier OffensiveAssist5 = new ArmorModifier("5 Offensive Assists", 5) { ShowModifier = false };
        public static ArmorModifier OffensiveAssist6 = new ArmorModifier("6 Offensive Assists", 6) { ShowModifier = false };
        public static ArmorModifier OffensiveAssist7 = new ArmorModifier("7 Offensive Assists", 7) { ShowModifier = false };
        public static ArmorModifier DefensiveAssist1 = new ArmorModifier("1 Defensive Assist", -1) { ShowModifier = false };
        public static ArmorModifier DefensiveAssist2 = new ArmorModifier("2 Defensive Assists", -2) { ShowModifier = false };
        public static ArmorModifier DefensiveAssist3 = new ArmorModifier("3 Defensive Assists", -3) { ShowModifier = false };
        public static ArmorModifier DefensiveAssist4 = new ArmorModifier("4 Defensive Assists", -4) { ShowModifier = false };
        public static ArmorModifier DefensiveAssist5 = new ArmorModifier("5 Defensive Assists", -5) { ShowModifier = false };
        public static ArmorModifier DirtyPlayer = new ArmorModifier("Dirty Player", 1) { };
        public static ArmorModifier Stakes = new ArmorModifier("Stakes", 1) { };
        public static ArmorModifier Chainsaw = new ArmorModifier("Chainsaw", 3) { };
        public static ArmorModifier Foul = new ArmorModifier("Foul", 1) { };
    }
}