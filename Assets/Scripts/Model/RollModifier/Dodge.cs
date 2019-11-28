using System.Collections.Generic;

namespace Fumbbl.Model
{
    public class DodgeModifier
    {
        public string Name { get; set; }
        public int Modifier { get; set; }
        public boolean TacklezoneModifier { get; set; }
        public boolean PrehensileTailModifier { get; set; }
    }

    public static class DodgeRollModifierExtensions
    {
        private static readonly Dictionary<string, DodgeRollModifier> DodgeRollModifiers= new Dictionary<string, DodgeRollModifier>();

        static DodgeRollModifierExtensions()
        {
            DodgeRollModifiers= new Dictionary<string, DodgeRollModifier>()
            {
                ["Stunty"] = new DodgeRollModifier() { Name = "Stunty", Modifier = 0, TacklezoneModifier = false, PrehensileTailModifier = false},
                ["Break Tackle"] = new DodgeRollModifier() { Name = "Break Tackle", Modifier = 0, TacklezoneModifier = false, PrehensileTailModifier = false},
                ["Two Heads"] = new DodgeRollModifier() { Name = "Two Heads", Modifier = -1, TacklezoneModifier = false, PrehensileTailModifier = false},
                ["Diving Tackle"] = new DodgeRollModifier() { Name = "Diving Tackle", Modifier = 2, TacklezoneModifier = false, PrehensileTailModifier = false},
                ["Titchy"] = new DodgeRollModifier() { Name = "Titchy", Modifier = -1, TacklezoneModifier = false, PrehensileTailModifier = false},
                ["1 Tacklezone"] = new DodgeRollModifier() { Name = "1 Tacklezone", Modifier = 1, TacklezoneModifier = true, PrehensileTailModifier = false},
                ["2 Tacklezones"] = new DodgeRollModifier() { Name = "2 Tacklezones", Modifier = 2, TacklezoneModifier = true, PrehensileTailModifier = false},
                ["3 Tacklezones"] = new DodgeRollModifier() { Name = "3 Tacklezones", Modifier = 3, TacklezoneModifier = true, PrehensileTailModifier = false},
                ["4 Tacklezones"] = new DodgeRollModifier() { Name = "4 Tacklezones", Modifier = 4, TacklezoneModifier = true, PrehensileTailModifier = false},
                ["5 Tacklezones"] = new DodgeRollModifier() { Name = "5 Tacklezones", Modifier = 5, TacklezoneModifier = true, PrehensileTailModifier = false},
                ["6 Tacklezones"] = new DodgeRollModifier() { Name = "6 Tacklezones", Modifier = 6, TacklezoneModifier = true, PrehensileTailModifier = false},
                ["7 Tacklezones"] = new DodgeRollModifier() { Name = "7 Tacklezones", Modifier = 7, TacklezoneModifier = true, PrehensileTailModifier = false},
                ["8 Tacklezones"] = new DodgeRollModifier() { Name = "8 Tacklezones", Modifier = 8, TacklezoneModifier = true, PrehensileTailModifier = false},
                ["1 Prehensile Tail"] = new DodgeRollModifier() { Name = "1 Prehensile Tail", Modifier = 1, TacklezoneModifier = false, PrehensileTailModifier = true},
                ["2 Prehensile Tails"] = new DodgeRollModifier() { Name = "2 Prehensile Tails", Modifier = 2, TacklezoneModifier = false, PrehensileTailModifier = true},
                ["3 Prehensile Tails"] = new DodgeRollModifier() { Name = "3 Prehensile Tails", Modifier = 3, TacklezoneModifier = false, PrehensileTailModifier = true},
                ["4 Prehensile Tails"] = new DodgeRollModifier() { Name = "4 Prehensile Tails", Modifier = 4, TacklezoneModifier = false, PrehensileTailModifier = true},
                ["5 Prehensile Tails"] = new DodgeRollModifier() { Name = "5 Prehensile Tails", Modifier = 5, TacklezoneModifier = false, PrehensileTailModifier = true},
                ["6 Prehensile Tails"] = new DodgeRollModifier() { Name = "6 Prehensile Tails", Modifier = 6, TacklezoneModifier = false, PrehensileTailModifier = true},
                ["7 Prehensile Tails"] = new DodgeRollModifier() { Name = "7 Prehensile Tails", Modifier = 7, TacklezoneModifier = false, PrehensileTailModifier = true},
                ["8 Prehensile Tails"] = new DodgeRollModifier() { Name = "8 Prehensile Tails", Modifier = 8, TacklezoneModifier = false, PrehensileTailModifier = true}
            }
        }

        public static DodgeRollModifier AsDodgeRollModifier(this FFBEnumeration ffbEnum)
        {
            return DodgeRollModifiers.ContainsKey(ffbEnum.key) ? DodgeRollModifiers[ffbEnum.key] : null;
        }
 }