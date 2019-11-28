using System.Collections.Generic;

namespace Fumbbl.Model
{
    public class PickupModifier
    {
        public string Name { get; set; }
        public int Modifier { get; set; }
        public bool TacklezoneModifier { get; set; }
    }

    public static class PickupModifierExtensions
    {
        private static readonly Dictionary<string, PickupModifier> PickupModifiers = new Dictionary<string, PickupModifier>();

        static PickupModifierExtensions()
        {
            PickupModifiers = new Dictionary<string, PickupModifier>()
            {
                ["Big Hand"] = new PickupModifier() { Name = "Big Hand", Modifier = 0, TacklezoneModifier = false},
                ["Pouring Rain"] = new PickupModifier() { Name = "Pouring Rain", Modifier = 1, TacklezoneModifier = false},
                ["Extra Arms"] = new PickupModifier() { Name = "Extra Arms", Modifier = -1, TacklezoneModifier = false},
                ["1 Tacklezone"] = new PickupModifier() { Name = "1 Tacklezone", Modifier = 1, TacklezoneModifier = true},
                ["2 Tacklezones"] = new PickupModifier() { Name = "2 Tacklezones", Modifier = 2, TacklezoneModifier = true},
                ["3 Tacklezones"] = new PickupModifier() { Name = "3 Tacklezones", Modifier = 3, TacklezoneModifier = true},
                ["4 Tacklezones"] = new PickupModifier() { Name = "4 Tacklezones", Modifier = 4, TacklezoneModifier = true},
                ["5 Tacklezones"] = new PickupModifier() { Name = "5 Tacklezones", Modifier = 5, TacklezoneModifier = true},
                ["6 Tacklezones"] = new PickupModifier() { Name = "6 Tacklezones", Modifier = 6, TacklezoneModifier = true},
                ["7 Tacklezones"] = new PickupModifier() { Name = "7 Tacklezones", Modifier = 7, TacklezoneModifier = true},
                ["8 Tacklezones"] = new PickupModifier() { Name = "8 Tacklezones", Modifier = 8, TacklezoneModifier = true}
            };
        }

        public static PickupModifier AsPickupModifier(this FFBEnumeration ffbEnum)
        {
            return PickupModifiers.ContainsKey(ffbEnum.key) ? PickupModifiers[ffbEnum.key] : null;
        }
    }
}