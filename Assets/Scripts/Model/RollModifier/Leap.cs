using System.Collections.Generic;

namespace Fumbbl.Model
{
    public class LeapModifier
    {
        public string Name { get; set; }
        public int Modifier { get; set; }
    }

    public static class LeapModifierExtensions
    {
        private static readonly Dictionary<string, LeapModifier> LeapModifiers = new Dictionary<string, LeapModifier>();

        static LeapModifierExtensions()
        {
            LeapModifiers = new Dictionary<string, LeapModifier>()
            {
                ["Very Long Legs"] = new LeapModifier() { Name = "Very Long Legs", Modifier = -1}
            };
        }

        public static LeapModifier AsLeapModifier(this FFBEnumeration ffbEnum)
        {
            return LeapModifiers.ContainsKey(ffbEnum.key) ? LeapModifiers[ffbEnum.key] : null;
        }
    }
}