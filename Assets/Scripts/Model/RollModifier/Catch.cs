using System.Collections.Generic;

namespace Fumbbl.Model
{
    public class CatchModifier
    {
        public string Name { get; set; }
        public int Modifier { get; set; }
        public boolean TacklezoneModifier { get; set; }
        public boolean DisturbingPresenceModifier { get; set; }
    }

    public static class CatchRollModifierExtensions
    {
        private static readonly Dictionary<string, CatchRollModifier> CatchRollModifiers= new Dictionary<string, CatchRollModifier>();

        static CatchRollModifierExtensions()
        {
            CatchRollModifiers= new Dictionary<string, CatchRollModifier>()
            {
                ["Accurate Pass"] = new CatchRollModifier() { Name = "Accurate Pass", Modifier = -1, TacklezoneModifier = false, DisturbingPresenceModifier = false},
                ["Nerves of Steel"] = new CatchRollModifier() { Name = "Nerves of Steel", Modifier = 0, TacklezoneModifier = false, DisturbingPresenceModifier = false},
                ["Extra Arms"] = new CatchRollModifier() { Name = "Extra Arms", Modifier = -1, TacklezoneModifier = false, DisturbingPresenceModifier = false},
                ["Pouring Rain"] = new CatchRollModifier() { Name = "Pouring Rain", Modifier = 1, TacklezoneModifier = false, DisturbingPresenceModifier = false},
                ["1 Tacklezone"] = new CatchRollModifier() { Name = "1 Tacklezone", Modifier = 1, TacklezoneModifier = true, DisturbingPresenceModifier = false},
                ["2 Tacklezones"] = new CatchRollModifier() { Name = "2 Tacklezones", Modifier = 2, TacklezoneModifier = true, DisturbingPresenceModifier = false},
                ["3 Tacklezones"] = new CatchRollModifier() { Name = "3 Tacklezones", Modifier = 3, TacklezoneModifier = true, DisturbingPresenceModifier = false},
                ["4 Tacklezones"] = new CatchRollModifier() { Name = "4 Tacklezones", Modifier = 4, TacklezoneModifier = true, DisturbingPresenceModifier = false},
                ["5 Tacklezones"] = new CatchRollModifier() { Name = "5 Tacklezones", Modifier = 5, TacklezoneModifier = true, DisturbingPresenceModifier = false},
                ["6 Tacklezones"] = new CatchRollModifier() { Name = "6 Tacklezones", Modifier = 6, TacklezoneModifier = true, DisturbingPresenceModifier = false},
                ["7 Tacklezones"] = new CatchRollModifier() { Name = "7 Tacklezones", Modifier = 7, TacklezoneModifier = true, DisturbingPresenceModifier = false},
                ["8 Tacklezones"] = new CatchRollModifier() { Name = "8 Tacklezones", Modifier = 8, TacklezoneModifier = true, DisturbingPresenceModifier = false},
                ["1 Disturbing Presence"] = new CatchRollModifier() { Name = "1 Disturbing Presence", Modifier = 1, TacklezoneModifier = false, DisturbingPresenceModifier = true},
                ["2 Disturbing Presences"] = new CatchRollModifier() { Name = "2 Disturbing Presences", Modifier = 2, TacklezoneModifier = false, DisturbingPresenceModifier = true},
                ["3 Disturbing Presences"] = new CatchRollModifier() { Name = "3 Disturbing Presences", Modifier = 3, TacklezoneModifier = false, DisturbingPresenceModifier = true},
                ["4 Disturbing Presences"] = new CatchRollModifier() { Name = "4 Disturbing Presences", Modifier = 4, TacklezoneModifier = false, DisturbingPresenceModifier = true},
                ["5 Disturbing Presences"] = new CatchRollModifier() { Name = "5 Disturbing Presences", Modifier = 5, TacklezoneModifier = false, DisturbingPresenceModifier = true},
                ["6 Disturbing Presences"] = new CatchRollModifier() { Name = "6 Disturbing Presences", Modifier = 6, TacklezoneModifier = false, DisturbingPresenceModifier = true},
                ["7 Disturbing Presences"] = new CatchRollModifier() { Name = "7 Disturbing Presences", Modifier = 7, TacklezoneModifier = false, DisturbingPresenceModifier = true},
                ["8 Disturbing Presences"] = new CatchRollModifier() { Name = "8 Disturbing Presences", Modifier = 8, TacklezoneModifier = false, DisturbingPresenceModifier = true},
                ["9 Disturbing Presences"] = new CatchRollModifier() { Name = "9 Disturbing Presences", Modifier = 9, TacklezoneModifier = false, DisturbingPresenceModifier = true},
                ["10 Disturbing Presences"] = new CatchRollModifier() { Name = "10 Disturbing Presences", Modifier = 10, TacklezoneModifier = false, DisturbingPresenceModifier = true},
                ["11 Disturbing Presences"] = new CatchRollModifier() { Name = "11 Disturbing Presences", Modifier = 11, TacklezoneModifier = false, DisturbingPresenceModifier = true},
                ["Diving Catch"] = new CatchRollModifier() { Name = "Diving Catch", Modifier = -1, TacklezoneModifier = false, DisturbingPresenceModifier = false},
                ["Hand Off"] = new CatchRollModifier() { Name = "Hand Off", Modifier = -1, TacklezoneModifier = false, DisturbingPresenceModifier = false}
            }
        }

        public static CatchRollModifier AsCatchRollModifier(this FFBEnumeration ffbEnum)
        {
            return CatchRollModifiers.ContainsKey(ffbEnum.key) ? CatchRollModifiers[ffbEnum.key] : null;
        }
 }