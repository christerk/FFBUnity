using System.Collections.Generic;

namespace Fumbbl.Model
{
    public class PassModifier
    {
        public string Name { get; set; }
        public int Modifier { get; set; }
        public bool TacklezoneModifier { get; set; }
        public bool DisturbingPresenceModifier { get; set; }
    }

    public static class PassModifierExtensions
    {
        private static readonly Dictionary<string, PassModifier> PassModifiers = new Dictionary<string, PassModifier>();

        static PassModifierExtensions()
        {
            PassModifiers = new Dictionary<string, PassModifier>()
            {
                ["Accurate"] = new PassModifier() { Name = "Accurate", Modifier = -1, TacklezoneModifier = false, DisturbingPresenceModifier = false},
                ["Nerves of Steel"] = new PassModifier() { Name = "Nerves of Steel", Modifier = 0, TacklezoneModifier = false, DisturbingPresenceModifier = false},
                ["Strong Arm"] = new PassModifier() { Name = "Strong Arm", Modifier = -1, TacklezoneModifier = false, DisturbingPresenceModifier = false},
                ["Very Sunny"] = new PassModifier() { Name = "Very Sunny", Modifier = 1, TacklezoneModifier = false, DisturbingPresenceModifier = false},
                ["Blizzard"] = new PassModifier() { Name = "Blizzard", Modifier = 0, TacklezoneModifier = false, DisturbingPresenceModifier = false},
                ["Stunty"] = new PassModifier() { Name = "Stunty", Modifier = 1, TacklezoneModifier = false, DisturbingPresenceModifier = false},
                ["1 Tacklezone"] = new PassModifier() { Name = "1 Tacklezone", Modifier = 1, TacklezoneModifier = true, DisturbingPresenceModifier = false},
                ["2 Tacklezones"] = new PassModifier() { Name = "2 Tacklezones", Modifier = 2, TacklezoneModifier = true, DisturbingPresenceModifier = false},
                ["3 Tacklezones"] = new PassModifier() { Name = "3 Tacklezones", Modifier = 3, TacklezoneModifier = true, DisturbingPresenceModifier = false},
                ["4 Tacklezones"] = new PassModifier() { Name = "4 Tacklezones", Modifier = 4, TacklezoneModifier = true, DisturbingPresenceModifier = false},
                ["5 Tacklezones"] = new PassModifier() { Name = "5 Tacklezones", Modifier = 5, TacklezoneModifier = true, DisturbingPresenceModifier = false},
                ["6 Tacklezones"] = new PassModifier() { Name = "6 Tacklezones", Modifier = 6, TacklezoneModifier = true, DisturbingPresenceModifier = false},
                ["7 Tacklezones"] = new PassModifier() { Name = "7 Tacklezones", Modifier = 7, TacklezoneModifier = true, DisturbingPresenceModifier = false},
                ["8 Tacklezones"] = new PassModifier() { Name = "8 Tacklezones", Modifier = 8, TacklezoneModifier = true, DisturbingPresenceModifier = false},
                ["1 Disturbing Presence"] = new PassModifier() { Name = "1 Disturbing Presence", Modifier = 1, TacklezoneModifier = false, DisturbingPresenceModifier = true},
                ["2 Disturbing Presences"] = new PassModifier() { Name = "2 Disturbing Presences", Modifier = 2, TacklezoneModifier = false, DisturbingPresenceModifier = true},
                ["3 Disturbing Presences"] = new PassModifier() { Name = "3 Disturbing Presences", Modifier = 3, TacklezoneModifier = false, DisturbingPresenceModifier = true},
                ["4 Disturbing Presences"] = new PassModifier() { Name = "4 Disturbing Presences", Modifier = 4, TacklezoneModifier = false, DisturbingPresenceModifier = true},
                ["5 Disturbing Presences"] = new PassModifier() { Name = "5 Disturbing Presences", Modifier = 5, TacklezoneModifier = false, DisturbingPresenceModifier = true},
                ["6 Disturbing Presences"] = new PassModifier() { Name = "6 Disturbing Presences", Modifier = 6, TacklezoneModifier = false, DisturbingPresenceModifier = true},
                ["7 Disturbing Presences"] = new PassModifier() { Name = "7 Disturbing Presences", Modifier = 7, TacklezoneModifier = false, DisturbingPresenceModifier = true},
                ["8 Disturbing Presences"] = new PassModifier() { Name = "8 Disturbing Presences", Modifier = 8, TacklezoneModifier = false, DisturbingPresenceModifier = true},
                ["9 Disturbing Presences"] = new PassModifier() { Name = "9 Disturbing Presences", Modifier = 9, TacklezoneModifier = false, DisturbingPresenceModifier = true},
                ["10 Disturbing Presences"] = new PassModifier() { Name = "10 Disturbing Presences", Modifier = 10, TacklezoneModifier = false, DisturbingPresenceModifier = true},
                ["11 Disturbing Presences"] = new PassModifier() { Name = "11 Disturbing Presences", Modifier = 11, TacklezoneModifier = false, DisturbingPresenceModifier = true},
                ["Throw Team-Mate"] = new PassModifier() { Name = "Throw Team-Mate", Modifier = 1, TacklezoneModifier = false, DisturbingPresenceModifier = false},
                ["Gromskull's Exploding Runes"] = new PassModifier() { Name = "Gromskull's Exploding Runes", Modifier = 1, TacklezoneModifier = false, DisturbingPresenceModifier = false}
            };
        }

        public static PassModifier AsPassModifier(this FFBEnumeration ffbEnum)
        {
            return PassModifiers.ContainsKey(ffbEnum.key) ? PassModifiers[ffbEnum.key] : null;
        }
    }
}