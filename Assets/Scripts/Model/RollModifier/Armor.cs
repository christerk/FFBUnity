using System.Collections.Generic;

namespace Fumbbl.Model
{
    public class ArmorModifier
    {
        public string Name { get; set; }
        public int Modifier { get; set; }
        public bool FoulAssistModifier { get; set; }
    }

    public static class ArmorModifierExtensions
    {
        private static readonly Dictionary<string, ArmorModifier> ArmorModifiers = new Dictionary<string, ArmorModifier>();

        static ArmorModifierExtensions()
        {
            ArmorModifiers = new Dictionary<string, ArmorModifier>()
            {
                ["Claws"] = new ArmorModifier() { Name = "Claws", Modifier = 0, FoulAssistModifier = false},
                ["Mighty Blow"] = new ArmorModifier() { Name = "Mighty Blow", Modifier = 1, FoulAssistModifier = false},
                ["1 Offensive Assist"] = new ArmorModifier() { Name = "1 Offensive Assist", Modifier = 1, FoulAssistModifier = true},
                ["2 Offensive Assists"] = new ArmorModifier() { Name = "2 Offensive Assists", Modifier = 2, FoulAssistModifier = true},
                ["3 Offensive Assists"] = new ArmorModifier() { Name = "3 Offensive Assists", Modifier = 3, FoulAssistModifier = true},
                ["4 Offensive Assists"] = new ArmorModifier() { Name = "4 Offensive Assists", Modifier = 4, FoulAssistModifier = true},
                ["5 Offensive Assists"] = new ArmorModifier() { Name = "5 Offensive Assists", Modifier = 5, FoulAssistModifier = true},
                ["6 Offensive Assists"] = new ArmorModifier() { Name = "6 Offensive Assists", Modifier = 6, FoulAssistModifier = true},
                ["7 Offensive Assists"] = new ArmorModifier() { Name = "7 Offensive Assists", Modifier = 7, FoulAssistModifier = true},
                ["1 Defensive Assist"] = new ArmorModifier() { Name = "1 Defensive Assist", Modifier = -1, FoulAssistModifier = true},
                ["2 Defensive Assists"] = new ArmorModifier() { Name = "2 Defensive Assists", Modifier = -2, FoulAssistModifier = true},
                ["3 Defensive Assists"] = new ArmorModifier() { Name = "3 Defensive Assists", Modifier = -3, FoulAssistModifier = true},
                ["4 Defensive Assists"] = new ArmorModifier() { Name = "4 Defensive Assists", Modifier = -4, FoulAssistModifier = true},
                ["5 Defensive Assists"] = new ArmorModifier() { Name = "5 Defensive Assists", Modifier = -5, FoulAssistModifier = true},
                ["Dirty Player"] = new ArmorModifier() { Name = "Dirty Player", Modifier = 1, FoulAssistModifier = false},
                ["Stakes"] = new ArmorModifier() { Name = "Stakes", Modifier = 1, FoulAssistModifier = false},
                ["Chainsaw"] = new ArmorModifier() { Name = "Chainsaw", Modifier = 3, FoulAssistModifier = false},
                ["Foul"] = new ArmorModifier() { Name = "Foul", Modifier = 1, FoulAssistModifier = false}
            };
        }

        public static ArmorModifier AsArmorModifier(this FFBEnumeration ffbEnum)
        {
            return ArmorModifiers.ContainsKey(ffbEnum.key) ? ArmorModifiers[ffbEnum.key] : null;
        }
    }
}