namespace Fumbbl.Model.RollModifier
{
    public class PickupModifier : AbstractModifier
    {
        public PickupModifier(string name, int modifier) : base(name, modifier) { }

        public static PickupModifier BigHand = new PickupModifier("Big Hand", 0) { SignMode = SignMode.Hidden, ShowModifier = false, ShowName = false };
        public static PickupModifier PouringRain = new PickupModifier("Pouring Rain", 1);
        public static PickupModifier ExtraArms = new PickupModifier("Extra Arms", -1);
        public static PickupModifier Tacklezone1 = new PickupModifier("1 Tacklezone", 1) { ShowModifier = false };
        public static PickupModifier Tacklezone2 = new PickupModifier("2 Tacklezones", 2) { ShowModifier = false };
        public static PickupModifier Tacklezone3 = new PickupModifier("3 Tacklezones", 3) { ShowModifier = false };
        public static PickupModifier Tacklezone4 = new PickupModifier("4 Tacklezones", 4) { ShowModifier = false };
        public static PickupModifier Tacklezone5 = new PickupModifier("5 Tacklezones", 5) { ShowModifier = false };
        public static PickupModifier Tacklezone6 = new PickupModifier("6 Tacklezones", 6) { ShowModifier = false };
        public static PickupModifier Tacklezone7 = new PickupModifier("7 Tacklezones", 7) { ShowModifier = false };
        public static PickupModifier Tacklezone8 = new PickupModifier("8 Tacklezones", 8) { ShowModifier = false };
    }
}