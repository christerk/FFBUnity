using System.Collections.Generic;

namespace Fumbbl.Model
{
    public class RightStuffModifier
    {
        public string Name { get; set; }
        public int Modifier { get; set; }
        public bool TacklezoneModifier { get; set; }
    }

    public static class RightStuffModifierExtensions
    {
        private static readonly Dictionary<string, RightStuffModifier> RightStuffModifiers = new Dictionary<string, RightStuffModifier>();

        static RightStuffModifierExtensions()
        {
            RightStuffModifiers = new Dictionary<string, RightStuffModifier>()
            {
                ["Swoop"] = new RightStuffModifier() { Name = "Swoop", Modifier = -1, TacklezoneModifier = false},
                ["1 Tacklezone"] = new RightStuffModifier() { Name = "1 Tacklezone", Modifier = 1, TacklezoneModifier = true},
                ["2 Tacklezones"] = new RightStuffModifier() { Name = "2 Tacklezones", Modifier = 2, TacklezoneModifier = true},
                ["3 Tacklezones"] = new RightStuffModifier() { Name = "3 Tacklezones", Modifier = 3, TacklezoneModifier = true},
                ["4 Tacklezones"] = new RightStuffModifier() { Name = "4 Tacklezones", Modifier = 4, TacklezoneModifier = true},
                ["5 Tacklezones"] = new RightStuffModifier() { Name = "5 Tacklezones", Modifier = 5, TacklezoneModifier = true},
                ["6 Tacklezones"] = new RightStuffModifier() { Name = "6 Tacklezones", Modifier = 6, TacklezoneModifier = true},
                ["7 Tacklezones"] = new RightStuffModifier() { Name = "7 Tacklezones", Modifier = 7, TacklezoneModifier = true},
                ["8 Tacklezones"] = new RightStuffModifier() { Name = "8 Tacklezones", Modifier = 8, TacklezoneModifier = true}
            };
        }

        public static RightStuffModifier AsRightStuffModifier(this FFBEnumeration ffbEnum)
        {
            return RightStuffModifiers.ContainsKey(ffbEnum.key) ? RightStuffModifiers[ffbEnum.key] : null;
        }
    }
}