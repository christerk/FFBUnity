using System.Collections.Generic;

namespace Fumbbl.Model
{
    public class DodgeModifier
    {
        public string Name { get; set; }
        public int Modifier { get; set; }
        public bool TacklezoneModifier { get; set; }
        public bool PrehensileTailModifier { get; set; }

        public static DodgeModifier Stunty = new DodgeModifier() { Name = "Stunty", Modifier = 0, TacklezoneModifier = false, PrehensileTailModifier = false };
        public static DodgeModifier BreakTackle = new DodgeModifier() { Name = "Break Tackle", Modifier = 0, TacklezoneModifier = false, PrehensileTailModifier = false };

    }

    public static class DodgeModifierExtensions
    {
        private static readonly Dictionary<string, DodgeModifier> DodgeModifiers = new Dictionary<string, DodgeModifier>();

        static DodgeModifierExtensions()
        {
            DodgeModifiers = new Dictionary<string, DodgeModifier>()
            {
                ["Stunty"] = DodgeModifier.Stunty,
                ["Break Tackle"] = DodgeModifier.BreakTackle,
                ["Two Heads"] = new DodgeModifier() { Name = "Two Heads", Modifier = -1, TacklezoneModifier = false, PrehensileTailModifier = false},
                ["Diving Tackle"] = new DodgeModifier() { Name = "Diving Tackle", Modifier = 2, TacklezoneModifier = false, PrehensileTailModifier = false},
                ["Titchy"] = new DodgeModifier() { Name = "Titchy", Modifier = -1, TacklezoneModifier = false, PrehensileTailModifier = false},
                ["1 Tacklezone"] = new DodgeModifier() { Name = "1 Tacklezone", Modifier = 1, TacklezoneModifier = true, PrehensileTailModifier = false},
                ["2 Tacklezones"] = new DodgeModifier() { Name = "2 Tacklezones", Modifier = 2, TacklezoneModifier = true, PrehensileTailModifier = false},
                ["3 Tacklezones"] = new DodgeModifier() { Name = "3 Tacklezones", Modifier = 3, TacklezoneModifier = true, PrehensileTailModifier = false},
                ["4 Tacklezones"] = new DodgeModifier() { Name = "4 Tacklezones", Modifier = 4, TacklezoneModifier = true, PrehensileTailModifier = false},
                ["5 Tacklezones"] = new DodgeModifier() { Name = "5 Tacklezones", Modifier = 5, TacklezoneModifier = true, PrehensileTailModifier = false},
                ["6 Tacklezones"] = new DodgeModifier() { Name = "6 Tacklezones", Modifier = 6, TacklezoneModifier = true, PrehensileTailModifier = false},
                ["7 Tacklezones"] = new DodgeModifier() { Name = "7 Tacklezones", Modifier = 7, TacklezoneModifier = true, PrehensileTailModifier = false},
                ["8 Tacklezones"] = new DodgeModifier() { Name = "8 Tacklezones", Modifier = 8, TacklezoneModifier = true, PrehensileTailModifier = false},
                ["1 Prehensile Tail"] = new DodgeModifier() { Name = "1 Prehensile Tail", Modifier = 1, TacklezoneModifier = false, PrehensileTailModifier = true},
                ["2 Prehensile Tails"] = new DodgeModifier() { Name = "2 Prehensile Tails", Modifier = 2, TacklezoneModifier = false, PrehensileTailModifier = true},
                ["3 Prehensile Tails"] = new DodgeModifier() { Name = "3 Prehensile Tails", Modifier = 3, TacklezoneModifier = false, PrehensileTailModifier = true},
                ["4 Prehensile Tails"] = new DodgeModifier() { Name = "4 Prehensile Tails", Modifier = 4, TacklezoneModifier = false, PrehensileTailModifier = true},
                ["5 Prehensile Tails"] = new DodgeModifier() { Name = "5 Prehensile Tails", Modifier = 5, TacklezoneModifier = false, PrehensileTailModifier = true},
                ["6 Prehensile Tails"] = new DodgeModifier() { Name = "6 Prehensile Tails", Modifier = 6, TacklezoneModifier = false, PrehensileTailModifier = true},
                ["7 Prehensile Tails"] = new DodgeModifier() { Name = "7 Prehensile Tails", Modifier = 7, TacklezoneModifier = false, PrehensileTailModifier = true},
                ["8 Prehensile Tails"] = new DodgeModifier() { Name = "8 Prehensile Tails", Modifier = 8, TacklezoneModifier = false, PrehensileTailModifier = true}
            };
        }

        public static DodgeModifier AsDodgeModifier(this FFBEnumeration ffbEnum)
        {
            return DodgeModifiers.ContainsKey(ffbEnum.key) ? DodgeModifiers[ffbEnum.key] : null;
        }
    }
}