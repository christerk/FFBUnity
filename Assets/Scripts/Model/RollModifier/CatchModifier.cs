using System.Collections.Generic;

namespace Fumbbl.Model.RollModifier
{
    public class CatchModifier : AbstractModifier
    {
        public CatchModifier(string name, int modifier) : base(name, modifier) { }

        public bool TacklezoneModifier { get; set; }
        public bool DisturbingPresenceModifier { get; set; }

        public static CatchModifier AccuratePass = new CatchModifier("Accurate Pass", -1) { TacklezoneModifier = false, DisturbingPresenceModifier = false};
        public static CatchModifier NervesOfSteel = new CatchModifier("Nerves of Steel", 0) { TacklezoneModifier = false, DisturbingPresenceModifier = false};
        public static CatchModifier ExtraArms = new CatchModifier("Extra Arms", -1) { TacklezoneModifier = false, DisturbingPresenceModifier = false };
        public static CatchModifier PouringRain = new CatchModifier("Pouring Rain", 1) { TacklezoneModifier = false, DisturbingPresenceModifier = false };
        public static CatchModifier Tacklezone1 = new CatchModifier("1 Tacklezone", 1) { TacklezoneModifier = true, DisturbingPresenceModifier = false };
        public static CatchModifier Tacklezone2 = new CatchModifier("2 Tacklezones", 2) { TacklezoneModifier = true, DisturbingPresenceModifier = false };
        public static CatchModifier Tacklezone3 = new CatchModifier("3 Tacklezones", 3) { TacklezoneModifier = true, DisturbingPresenceModifier = false };
        public static CatchModifier Tacklezone4 = new CatchModifier("4 Tacklezones", 4) { TacklezoneModifier = true, DisturbingPresenceModifier = false };
        public static CatchModifier Tacklezone5 = new CatchModifier("5 Tacklezones", 5) { TacklezoneModifier = true, DisturbingPresenceModifier = false };
        public static CatchModifier Tacklezone6 = new CatchModifier("6 Tacklezones", 6) { TacklezoneModifier = true, DisturbingPresenceModifier = false };
        public static CatchModifier Tacklezone7 = new CatchModifier("7 Tacklezones", 7) { TacklezoneModifier = true, DisturbingPresenceModifier = false };
        public static CatchModifier Tacklezone8 = new CatchModifier("8 Tacklezones", 8) { TacklezoneModifier = true, DisturbingPresenceModifier = false };
        public static CatchModifier DisturbingPresence1 = new CatchModifier("1 Disturbing Presence", 1) { TacklezoneModifier = false, DisturbingPresenceModifier = true };
        public static CatchModifier DisturbingPresence2 = new CatchModifier("2 Disturbing Presences", 2) { TacklezoneModifier = false, DisturbingPresenceModifier = true };
        public static CatchModifier DisturbingPresence3 = new CatchModifier("3 Disturbing Presences", 3) { TacklezoneModifier = false, DisturbingPresenceModifier = true };
        public static CatchModifier DisturbingPresence4 = new CatchModifier("4 Disturbing Presences", 4) { TacklezoneModifier = false, DisturbingPresenceModifier = true };
        public static CatchModifier DisturbingPresence5 = new CatchModifier("5 Disturbing Presences", 5) { TacklezoneModifier = false, DisturbingPresenceModifier = true };
        public static CatchModifier DisturbingPresence6 = new CatchModifier("6 Disturbing Presences", 6) { TacklezoneModifier = false, DisturbingPresenceModifier = true };
        public static CatchModifier DisturbingPresence7 = new CatchModifier("7 Disturbing Presences", 7) { TacklezoneModifier = false, DisturbingPresenceModifier = true };
        public static CatchModifier DisturbingPresence8 = new CatchModifier("8 Disturbing Presences", 8) { TacklezoneModifier = false, DisturbingPresenceModifier = true };
        public static CatchModifier DisturbingPresence9 = new CatchModifier("9 Disturbing Presences", 9) { TacklezoneModifier = false, DisturbingPresenceModifier = true };
        public static CatchModifier DisturbingPresence10 = new CatchModifier("10 Disturbing Presences", 10) { TacklezoneModifier = false, DisturbingPresenceModifier = true };
        public static CatchModifier DisturbingPresence11 = new CatchModifier("11 Disturbing Presences", 11) { TacklezoneModifier = false, DisturbingPresenceModifier = true };
        public static CatchModifier DivingCatch = new CatchModifier("Diving Catch", -1) { TacklezoneModifier = false, DisturbingPresenceModifier = false };
        public static CatchModifier HandOff = new CatchModifier("Hand Off", -1) { TacklezoneModifier = false, DisturbingPresenceModifier = false };
    }
}