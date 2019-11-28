using System.Collections.Generic;

namespace Fumbbl.Model
{
    public class GoForItModifier
    {
        public string Name { get; set; }
        public int Modifier { get; set; }
    }

    public static class GoForItModifierExtensions
    {
        private static readonly Dictionary<string, GoForItModifier> GoForItModifiers = new Dictionary<string, GoForItModifier>();

        static GoForItModifierExtensions()
        {
            GoForItModifiers = new Dictionary<string, GoForItModifier>()
            {
                ["Blizzard"] = new GoForItModifier() { Name = ""Blizzard"", Modifier = 1},
                ["Greased Shoes"] = new GoForItModifier() { Name = "Greased Shoes", Modifier = 3}
            }
        }

        public static GoForItModifier AsGoForItModifier(this FFBEnumeration ffbEnum)
        {
            return GoForItModifiers.ContainsKey(ffbEnum.key) ? GoForItModifiers[ffbEnum.key] : null;
        }
 }