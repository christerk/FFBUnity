namespace Fumbbl.Model.RollModifier
{
    public class InterceptionModifier : AbstractModifier
    {
        public InterceptionModifier(string name, int modifier) : base(name, modifier) { }

        public static InterceptionModifier NervesOfSteel = new InterceptionModifier("Nerves of Steel", 0) { SignMode = SignMode.Hidden, ShowModifier = false, ShowName = false };
        public static InterceptionModifier ExtraArms = new InterceptionModifier("Extra Arms", -1);
        public static InterceptionModifier VeryLongLegs = new InterceptionModifier("Very Long Legs", -1);
        public static InterceptionModifier PouringRain = new InterceptionModifier("Pouring Rain", 1);
        public static InterceptionModifier Tacklezone1 = new InterceptionModifier("1 Tacklezone", 1) { ShowModifier = false };
        public static InterceptionModifier Tacklezone2 = new InterceptionModifier("2 Tacklezones", 2) { ShowModifier = false };
        public static InterceptionModifier Tacklezone3 = new InterceptionModifier("3 Tacklezones", 3) { ShowModifier = false };
        public static InterceptionModifier Tacklezone4 = new InterceptionModifier("4 Tacklezones", 4) { ShowModifier = false };
        public static InterceptionModifier Tacklezone5 = new InterceptionModifier("5 Tacklezones", 5) { ShowModifier = false };
        public static InterceptionModifier Tacklezone6 = new InterceptionModifier("6 Tacklezones", 6) { ShowModifier = false };
        public static InterceptionModifier Tacklezone7 = new InterceptionModifier("7 Tacklezones", 7) { ShowModifier = false };
        public static InterceptionModifier Tacklezone8 = new InterceptionModifier("8 Tacklezones", 8) { ShowModifier = false };
        public static InterceptionModifier DisturbingPresence1 = new InterceptionModifier("1 Disturbing Presence", 1) { ShowModifier = false };
        public static InterceptionModifier DisturbingPresence2 = new InterceptionModifier("2 Disturbing Presences", 2) { ShowModifier = false };
        public static InterceptionModifier DisturbingPresence3 = new InterceptionModifier("3 Disturbing Presences", 3) { ShowModifier = false };
        public static InterceptionModifier DisturbingPresence4 = new InterceptionModifier("4 Disturbing Presences", 4) { ShowModifier = false };
        public static InterceptionModifier DisturbingPresence5 = new InterceptionModifier("5 Disturbing Presences", 5) { ShowModifier = false };
        public static InterceptionModifier DisturbingPresence6 = new InterceptionModifier("6 Disturbing Presences", 6) { ShowModifier = false };
        public static InterceptionModifier DisturbingPresence7 = new InterceptionModifier("7 Disturbing Presences", 7) { ShowModifier = false };
        public static InterceptionModifier DisturbingPresence8 = new InterceptionModifier("8 Disturbing Presences", 8) { ShowModifier = false };
        public static InterceptionModifier DisturbingPresence9 = new InterceptionModifier("9 Disturbing Presences", 9) { ShowModifier = false };
        public static InterceptionModifier DisturbingPresence10 = new InterceptionModifier("10 Disturbing Presences", 10) { ShowModifier = false };
        public static InterceptionModifier DisturbingPresence11 = new InterceptionModifier("11 Disturbing Presences", 11) { ShowModifier = false };
        public static InterceptionModifier FawndoughsHeadband = new InterceptionModifier("Fawndough's Headband", -1);
        public static InterceptionModifier MagicGlovesOfJarkLongarm = new InterceptionModifier("Magic Gloves of Jark Longarm", -1);
    }
}