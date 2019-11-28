using System.Collections.Generic;

namespace Fumbbl.Model
{
    public class InterceptionModifier
    {
        public string Name { get; set; }
        public int Modifier { get; set; }
        public boolean TacklezoneModifier { get; set; }
        public boolean DisturbingPresenceModifier { get; set; }
    }

    public static class InterceptionModifierExtensions
    {
        private static readonly Dictionary<string, InterceptionModifier> InterceptionModifiers = new Dictionary<string, InterceptionModifier>();

        static InterceptionModifierExtensions()
        {
            InterceptionModifiers = new Dictionary<string, InterceptionModifier>()
            {
                ["Nerves of Steel"] = new InterceptionModifier() { Name = "Nerves of Steel", Modifier = 0, TacklezoneModifier = false, DisturbingPresenceModifier = false},
                ["Extra Arms"] = new InterceptionModifier() { Name = "Extra Arms", Modifier = -1, TacklezoneModifier = false, DisturbingPresenceModifier = false},
                ["Very Long Legs"] = new InterceptionModifier() { Name = "Very Long Legs", Modifier = -1, TacklezoneModifier = false, DisturbingPresenceModifier = false},
                ["Pouring Rain"] = new InterceptionModifier() { Name = "Pouring Rain", Modifier = 1, TacklezoneModifier = false, DisturbingPresenceModifier = false},
                ["1 Tacklezone"] = new InterceptionModifier() { Name = "1 Tacklezone", Modifier = 1, TacklezoneModifier = true, DisturbingPresenceModifier = false},
                ["2 Tacklezones"] = new InterceptionModifier() { Name = "2 Tacklezones", Modifier = 2, TacklezoneModifier = true, DisturbingPresenceModifier = false},
                ["3 Tacklezones"] = new InterceptionModifier() { Name = "3 Tacklezones", Modifier = 3, TacklezoneModifier = true, DisturbingPresenceModifier = false},
                ["4 Tacklezones"] = new InterceptionModifier() { Name = "4 Tacklezones", Modifier = 4, TacklezoneModifier = true, DisturbingPresenceModifier = false},
                ["5 Tacklezones"] = new InterceptionModifier() { Name = "5 Tacklezones", Modifier = 5, TacklezoneModifier = true, DisturbingPresenceModifier = false},
                ["6 Tacklezones"] = new InterceptionModifier() { Name = "6 Tacklezones", Modifier = 6, TacklezoneModifier = true, DisturbingPresenceModifier = false},
                ["7 Tacklezones"] = new InterceptionModifier() { Name = "7 Tacklezones", Modifier = 7, TacklezoneModifier = true, DisturbingPresenceModifier = false},
                ["8 Tacklezones"] = new InterceptionModifier() { Name = "8 Tacklezones", Modifier = 8, TacklezoneModifier = true, DisturbingPresenceModifier = false},
                ["1 Disturbing Presence"] = new InterceptionModifier() { Name = "1 Disturbing Presence", Modifier = 1, TacklezoneModifier = false, DisturbingPresenceModifier = true},
                ["2 Disturbing Presences"] = new InterceptionModifier() { Name = "2 Disturbing Presences", Modifier = 2, TacklezoneModifier = false, DisturbingPresenceModifier = true},
                ["3 Disturbing Presences"] = new InterceptionModifier() { Name = "3 Disturbing Presences", Modifier = 3, TacklezoneModifier = false, DisturbingPresenceModifier = true},
                ["4 Disturbing Presences"] = new InterceptionModifier() { Name = "4 Disturbing Presences", Modifier = 4, TacklezoneModifier = false, DisturbingPresenceModifier = true},
                ["5 Disturbing Presences"] = new InterceptionModifier() { Name = "5 Disturbing Presences", Modifier = 5, TacklezoneModifier = false, DisturbingPresenceModifier = true},
                ["6 Disturbing Presences"] = new InterceptionModifier() { Name = "6 Disturbing Presences", Modifier = 6, TacklezoneModifier = false, DisturbingPresenceModifier = true},
                ["7 Disturbing Presences"] = new InterceptionModifier() { Name = "7 Disturbing Presences", Modifier = 7, TacklezoneModifier = false, DisturbingPresenceModifier = true},
                ["8 Disturbing Presences"] = new InterceptionModifier() { Name = "8 Disturbing Presences", Modifier = 8, TacklezoneModifier = false, DisturbingPresenceModifier = true},
                ["9 Disturbing Presences"] = new InterceptionModifier() { Name = "9 Disturbing Presences", Modifier = 9, TacklezoneModifier = false, DisturbingPresenceModifier = true},
                ["10 Disturbing Presences"] = new InterceptionModifier() { Name = "10 Disturbing Presences", Modifier = 10, TacklezoneModifier = false, DisturbingPresenceModifier = true},
                ["11 Disturbing Presences"] = new InterceptionModifier() { Name = "11 Disturbing Presences", Modifier = 11, TacklezoneModifier = false, DisturbingPresenceModifier = true},
                ["Fawndough's Headband"] = new InterceptionModifier() { Name = "Fawndough's Headband", Modifier = -1, TacklezoneModifier = false, DisturbingPresenceModifier = false},
                ["Magic Gloves of Jark Longarm"] = new InterceptionModifier() { Name = "Magic Gloves of Jark Longarm", Modifier = -1, TacklezoneModifier = false, DisturbingPresenceModifier = false}
            }
        }

        public static InterceptionModifier AsInterceptionModifier(this FFBEnumeration ffbEnum)
        {
            return InterceptionModifiers.ContainsKey(ffbEnum.key) ? InterceptionModifiers[ffbEnum.key] : null;
        }
 }