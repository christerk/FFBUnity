namespace Fumbbl.Model.RollModifier
{
    public class RightStuffModifier : AbstractModifier
    {
        public RightStuffModifier(string name, int modifier) : base(name, modifier) { }
        public bool TacklezoneModifier { get; set; }

        public static RightStuffModifier Swoop = new RightStuffModifier("Swoop", -1) { TacklezoneModifier = false };
        public static RightStuffModifier Tacklezone1 = new RightStuffModifier("1 Tacklezone", 1) { TacklezoneModifier = true };
        public static RightStuffModifier Tacklezone2 = new RightStuffModifier("2 Tacklezones", 2) { TacklezoneModifier = true };
        public static RightStuffModifier Tacklezone3 = new RightStuffModifier("3 Tacklezones", 3) { TacklezoneModifier = true };
        public static RightStuffModifier Tacklezone4 = new RightStuffModifier("4 Tacklezones", 4) { TacklezoneModifier = true };
        public static RightStuffModifier Tacklezone5 = new RightStuffModifier("5 Tacklezones", 5) { TacklezoneModifier = true };
        public static RightStuffModifier Tacklezone6 = new RightStuffModifier("6 Tacklezones", 6) { TacklezoneModifier = true };
        public static RightStuffModifier Tacklezone7 = new RightStuffModifier("7 Tacklezones", 7) { TacklezoneModifier = true };
        public static RightStuffModifier Tacklezone8 = new RightStuffModifier("8 Tacklezones", 8) { TacklezoneModifier = true };
    }
}