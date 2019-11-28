using System.Collections.Generic;

namespace Fumbbl.Model
{
    public class ArmorModifier
    {
        public string Name { get; set; }
        public int Modifier { get; set; }
        public boolean FoulAssistModifier { get; set; }
    }

    public static class ArmorRollModifierExtensions
    {
        private static readonly Dictionary<string, ArmorRollModifier> ArmorRollModifiers= new Dictionary<string, ArmorRollModifier>();

        static ArmorRollModifierExtensions()
        {
            ArmorRollModifiers= new Dictionary<string, ArmorRollModifier>()
            {
                ["Claws"] = new ArmorRollModifier() { Name = "Claws", Modifier = 0, FoulAssistModifier = false},
                ["Mighty Blow"] = new ArmorRollModifier() { Name = "Mighty Blow", Modifier = 1, FoulAssistModifier = false},
                ["1 Offensive Assist"] = new ArmorRollModifier() { Name = "1 Offensive Assist", Modifier = 1, FoulAssistModifier = true},
                ["2 Offensive Assists"] = new ArmorRollModifier() { Name = "2 Offensive Assists", Modifier = 2, FoulAssistModifier = true},
                ["3 Offensive Assists"] = new ArmorRollModifier() { Name = "3 Offensive Assists", Modifier = 3, FoulAssistModifier = true},
                ["4 Offensive Assists"] = new ArmorRollModifier() { Name = "4 Offensive Assists", Modifier = 4, FoulAssistModifier = true},
                ["5 Offensive Assists"] = new ArmorRollModifier() { Name = "5 Offensive Assists", Modifier = 5, FoulAssistModifier = true},
                ["6 Offensive Assists"] = new ArmorRollModifier() { Name = "6 Offensive Assists", Modifier = 6, FoulAssistModifier = true},
                ["7 Offensive Assists"] = new ArmorRollModifier() { Name = "7 Offensive Assists", Modifier = 7, FoulAssistModifier = true},
                ["1 Defensive Assist"] = new ArmorRollModifier() { Name = "1 Defensive Assist", Modifier = -1, FoulAssistModifier = true},
                ["2 Defensive Assists"] = new ArmorRollModifier() { Name = "2 Defensive Assists", Modifier = -2, FoulAssistModifier = true},
                ["3 Defensive Assists"] = new ArmorRollModifier() { Name = "3 Defensive Assists", Modifier = -3, FoulAssistModifier = true},
                ["4 Defensive Assists"] = new ArmorRollModifier() { Name = "4 Defensive Assists", Modifier = -4, FoulAssistModifier = true},
                ["5 Defensive Assists"] = new ArmorRollModifier() { Name = "5 Defensive Assists", Modifier = -5, FoulAssistModifier = true},
                ["Dirty Player"] = new ArmorRollModifier() { Name = "Dirty Player", Modifier = 1, FoulAssistModifier = false},
                ["Stakes"] = new ArmorRollModifier() { Name = "Stakes", Modifier = 1, FoulAssistModifier = false},
                ["Chainsaw"] = new ArmorRollModifier() { Name = "Chainsaw", Modifier = 3, FoulAssistModifier = false},
                ["Foul"] = new ArmorRollModifier() { Name = "Foul", Modifier = 1, FoulAssistModifier = false}
            }
        }

        public static ArmorRollModifier AsArmorRollModifier(this FFBEnumeration ffbEnum)
        {
            return ArmorRollModifiers.ContainsKey(ffbEnum.key) ? ArmorRollModifiers[ffbEnum.key] : null;
        }
 }