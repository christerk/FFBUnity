using System.Collections.Generic;

namespace Fumbbl.Model
{
    public class CatchModifier
    {
        public string Name { get; set; }
        public int Modifier { get; set; }
        public bool TacklezoneModifier { get; set; }
        public bool DisturbingPresenceModifier { get; set; }
    }

    public static class CatchModifierExtensions
    {
        private static readonly Dictionary<string, CatchModifier> CatchModifiers = new Dictionary<string, CatchModifier>();

        static CatchModifierExtensions()
        {
            CatchModifiers = new Dictionary<string, CatchModifier>()
            {
                ["Accurate Pass"] = new CatchModifier() { Name = "Accurate Pass", Modifier = -1, TacklezoneModifier = false, DisturbingPresenceModifier = false},
                ["Nerves of Steel"] = new CatchModifier() { Name = "Nerves of Steel", Modifier = 0, TacklezoneModifier = false, DisturbingPresenceModifier = false},
                ["Extra Arms"] = new CatchModifier() { Name = "Extra Arms", Modifier = -1, TacklezoneModifier = false, DisturbingPresenceModifier = false},
                ["Pouring Rain"] = new CatchModifier() { Name = "Pouring Rain", Modifier = 1, TacklezoneModifier = false, DisturbingPresenceModifier = false},
                ["1 Tacklezone"] = new CatchModifier() { Name = "1 Tacklezone", Modifier = 1, TacklezoneModifier = true, DisturbingPresenceModifier = false},
                ["2 Tacklezones"] = new CatchModifier() { Name = "2 Tacklezones", Modifier = 2, TacklezoneModifier = true, DisturbingPresenceModifier = false},
                ["3 Tacklezones"] = new CatchModifier() { Name = "3 Tacklezones", Modifier = 3, TacklezoneModifier = true, DisturbingPresenceModifier = false},
                ["4 Tacklezones"] = new CatchModifier() { Name = "4 Tacklezones", Modifier = 4, TacklezoneModifier = true, DisturbingPresenceModifier = false},
                ["5 Tacklezones"] = new CatchModifier() { Name = "5 Tacklezones", Modifier = 5, TacklezoneModifier = true, DisturbingPresenceModifier = false},
                ["6 Tacklezones"] = new CatchModifier() { Name = "6 Tacklezones", Modifier = 6, TacklezoneModifier = true, DisturbingPresenceModifier = false},
                ["7 Tacklezones"] = new CatchModifier() { Name = "7 Tacklezones", Modifier = 7, TacklezoneModifier = true, DisturbingPresenceModifier = false},
                ["8 Tacklezones"] = new CatchModifier() { Name = "8 Tacklezones", Modifier = 8, TacklezoneModifier = true, DisturbingPresenceModifier = false},
                ["1 Disturbing Presence"] = new CatchModifier() { Name = "1 Disturbing Presence", Modifier = 1, TacklezoneModifier = false, DisturbingPresenceModifier = true},
                ["2 Disturbing Presences"] = new CatchModifier() { Name = "2 Disturbing Presences", Modifier = 2, TacklezoneModifier = false, DisturbingPresenceModifier = true},
                ["3 Disturbing Presences"] = new CatchModifier() { Name = "3 Disturbing Presences", Modifier = 3, TacklezoneModifier = false, DisturbingPresenceModifier = true},
                ["4 Disturbing Presences"] = new CatchModifier() { Name = "4 Disturbing Presences", Modifier = 4, TacklezoneModifier = false, DisturbingPresenceModifier = true},
                ["5 Disturbing Presences"] = new CatchModifier() { Name = "5 Disturbing Presences", Modifier = 5, TacklezoneModifier = false, DisturbingPresenceModifier = true},
                ["6 Disturbing Presences"] = new CatchModifier() { Name = "6 Disturbing Presences", Modifier = 6, TacklezoneModifier = false, DisturbingPresenceModifier = true},
                ["7 Disturbing Presences"] = new CatchModifier() { Name = "7 Disturbing Presences", Modifier = 7, TacklezoneModifier = false, DisturbingPresenceModifier = true},
                ["8 Disturbing Presences"] = new CatchModifier() { Name = "8 Disturbing Presences", Modifier = 8, TacklezoneModifier = false, DisturbingPresenceModifier = true},
                ["9 Disturbing Presences"] = new CatchModifier() { Name = "9 Disturbing Presences", Modifier = 9, TacklezoneModifier = false, DisturbingPresenceModifier = true},
                ["10 Disturbing Presences"] = new CatchModifier() { Name = "10 Disturbing Presences", Modifier = 10, TacklezoneModifier = false, DisturbingPresenceModifier = true},
                ["11 Disturbing Presences"] = new CatchModifier() { Name = "11 Disturbing Presences", Modifier = 11, TacklezoneModifier = false, DisturbingPresenceModifier = true},
                ["Diving Catch"] = new CatchModifier() { Name = "Diving Catch", Modifier = -1, TacklezoneModifier = false, DisturbingPresenceModifier = false},
                ["Hand Off"] = new CatchModifier() { Name = "Hand Off", Modifier = -1, TacklezoneModifier = false, DisturbingPresenceModifier = false}
            };
        }

        public static CatchModifier AsCatchModifier(this FFBEnumeration ffbEnum)
        {
            return CatchModifiers.ContainsKey(ffbEnum.key) ? CatchModifiers[ffbEnum.key] : null;
        }
    }
}