namespace Fumbbl.Model.RollModifier
{
    public class PassModifier : AbstractModifier
    {
        public PassModifier(string name, int modifier) : base(name, modifier) { }
        public bool TacklezoneModifier { get; set; }
        public bool DisturbingPresenceModifier { get; set; }

        public static PassModifier Accurate = new PassModifier("Accurate", -1) { TacklezoneModifier = false, DisturbingPresenceModifier = false };
        public static PassModifier NervesOfSteel = new PassModifier("Nerves of Steel", 0) { TacklezoneModifier = false, DisturbingPresenceModifier = false };
        public static PassModifier StrongArm = new PassModifier("Strong Arm", -1) { TacklezoneModifier = false, DisturbingPresenceModifier = false };
        public static PassModifier VerySunny = new PassModifier("Very Sunny", 1) { TacklezoneModifier = false, DisturbingPresenceModifier = false };
        public static PassModifier Blizzard = new PassModifier("Blizzard", 0) { TacklezoneModifier = false, DisturbingPresenceModifier = false };
        public static PassModifier Stunty = new PassModifier("Stunty", 1) { TacklezoneModifier = false, DisturbingPresenceModifier = false };
        public static PassModifier Tacklezone1 = new PassModifier("1 Tacklezone", 1) { TacklezoneModifier = true, DisturbingPresenceModifier = false };
        public static PassModifier Tacklezone2 = new PassModifier("2 Tacklezones", 2) { TacklezoneModifier = true, DisturbingPresenceModifier = false };
        public static PassModifier Tacklezone3 = new PassModifier("3 Tacklezones", 3) { TacklezoneModifier = true, DisturbingPresenceModifier = false };
        public static PassModifier Tacklezone4 = new PassModifier("4 Tacklezones", 4) { TacklezoneModifier = true, DisturbingPresenceModifier = false };
        public static PassModifier Tacklezone5 = new PassModifier("5 Tacklezones", 5) { TacklezoneModifier = true, DisturbingPresenceModifier = false };
        public static PassModifier Tacklezone6 = new PassModifier("6 Tacklezones", 6) { TacklezoneModifier = true, DisturbingPresenceModifier = false };
        public static PassModifier Tacklezone7 = new PassModifier("7 Tacklezones", 7) { TacklezoneModifier = true, DisturbingPresenceModifier = false };
        public static PassModifier Tacklezone8 = new PassModifier("8 Tacklezones", 8) { TacklezoneModifier = true, DisturbingPresenceModifier = false };
        public static PassModifier DisturbingPresence1 = new PassModifier("1 Disturbing Presence", 1) { TacklezoneModifier = false, DisturbingPresenceModifier = true };
        public static PassModifier DisturbingPresence2 = new PassModifier("2 Disturbing Presences", 2) { TacklezoneModifier = false, DisturbingPresenceModifier = true };
        public static PassModifier DisturbingPresence3 = new PassModifier("3 Disturbing Presences", 3) { TacklezoneModifier = false, DisturbingPresenceModifier = true };
        public static PassModifier DisturbingPresence4 = new PassModifier("4 Disturbing Presences", 4) { TacklezoneModifier = false, DisturbingPresenceModifier = true };
        public static PassModifier DisturbingPresence5 = new PassModifier("5 Disturbing Presences", 5) { TacklezoneModifier = false, DisturbingPresenceModifier = true };
        public static PassModifier DisturbingPresence6 = new PassModifier("6 Disturbing Presences", 6) { TacklezoneModifier = false, DisturbingPresenceModifier = true };
        public static PassModifier DisturbingPresence7 = new PassModifier("7 Disturbing Presences", 7) { TacklezoneModifier = false, DisturbingPresenceModifier = true };
        public static PassModifier DisturbingPresence8 = new PassModifier("8 Disturbing Presences", 8) { TacklezoneModifier = false, DisturbingPresenceModifier = true };
        public static PassModifier DisturbingPresence9 = new PassModifier("9 Disturbing Presences", 9) { TacklezoneModifier = false, DisturbingPresenceModifier = true };
        public static PassModifier DisturbingPresence10 = new PassModifier("10 Disturbing Presences", 10) { TacklezoneModifier = false, DisturbingPresenceModifier = true };
        public static PassModifier DisturbingPresence11 = new PassModifier("11 Disturbing Presences", 11) { TacklezoneModifier = false, DisturbingPresenceModifier = true };
        public static PassModifier ThrowTeamMate = new PassModifier("Throw Team-Mate", 1) { TacklezoneModifier = false, DisturbingPresenceModifier = false };
        public static PassModifier GromskullsExplodingRunes = new PassModifier("Gromskull's Exploding Runes", 1) { TacklezoneModifier = false, DisturbingPresenceModifier = false };
    }
}