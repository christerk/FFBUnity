﻿namespace Fumbbl.Model.RollModifier
{
    public class PickupModifier : AbstractModifier
    {
        public PickupModifier(string name, int modifier) : base(name, modifier) { }
        public bool TacklezoneModifier { get; set; }

        public static PickupModifier BigHand = new PickupModifier("Big Hand", 0) { TacklezoneModifier = false };
        public static PickupModifier PouringRain = new PickupModifier("Pouring Rain", 1) { TacklezoneModifier = false };
        public static PickupModifier ExtraArms = new PickupModifier("Extra Arms", -1) { TacklezoneModifier = false };
        public static PickupModifier Tacklezone1 = new PickupModifier("1 Tacklezone", 1) { TacklezoneModifier = true };
        public static PickupModifier Tacklezone2 = new PickupModifier("2 Tacklezones", 2) { TacklezoneModifier = true };
        public static PickupModifier Tacklezone3 = new PickupModifier("3 Tacklezones", 3) { TacklezoneModifier = true };
        public static PickupModifier Tacklezone4 = new PickupModifier("4 Tacklezones", 4) { TacklezoneModifier = true };
        public static PickupModifier Tacklezone5 = new PickupModifier("5 Tacklezones", 5) { TacklezoneModifier = true };
        public static PickupModifier Tacklezone6 = new PickupModifier("6 Tacklezones", 6) { TacklezoneModifier = true };
        public static PickupModifier Tacklezone7 = new PickupModifier("7 Tacklezones", 7) { TacklezoneModifier = true };
        public static PickupModifier Tacklezone8 = new PickupModifier("8 Tacklezones", 8) { TacklezoneModifier = true };
    }
}