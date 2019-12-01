using System.Collections.Generic;
namespace Fumbbl.Model.RollModifier
{
    public class ArmorModifier : AbstractModifier
    {
        public ArmorModifier(string name, int modifier) : base(name, modifier) { }

        public bool FoulAssistModifier { get; set; }

        public static ArmorModifier Claws = new ArmorModifier("Claws", 0) { FoulAssistModifier = false };
        public static ArmorModifier MightyBlow = new ArmorModifier("Mighty Blow", 1) { FoulAssistModifier = false };
        public static ArmorModifier OffensiveAssist1 = new ArmorModifier("1 Offensive Assist", 1) { FoulAssistModifier = true };
        public static ArmorModifier OffensiveAssist2 = new ArmorModifier("2 Offensive Assists", 2) { FoulAssistModifier = true };
        public static ArmorModifier OffensiveAssist3 = new ArmorModifier("3 Offensive Assists", 3) { FoulAssistModifier = true };
        public static ArmorModifier OffensiveAssist4 = new ArmorModifier("4 Offensive Assists", 4) { FoulAssistModifier = true };
        public static ArmorModifier OffensiveAssist5 = new ArmorModifier("5 Offensive Assists", 5) { FoulAssistModifier = true };
        public static ArmorModifier OffensiveAssist6 = new ArmorModifier("6 Offensive Assists", 6) { FoulAssistModifier = true };
        public static ArmorModifier OffensiveAssist7 = new ArmorModifier("7 Offensive Assists", 7) { FoulAssistModifier = true };
        public static ArmorModifier DefensiveAssist1 = new ArmorModifier("1 Defensive Assist", -1) { FoulAssistModifier = true };
        public static ArmorModifier DefensiveAssist2 = new ArmorModifier("2 Defensive Assists", -2) { FoulAssistModifier = true };
        public static ArmorModifier DefensiveAssist3 = new ArmorModifier("3 Defensive Assists", -3) { FoulAssistModifier = true };
        public static ArmorModifier DefensiveAssist4 = new ArmorModifier("4 Defensive Assists", -4) { FoulAssistModifier = true };
        public static ArmorModifier DefensiveAssist5 = new ArmorModifier("5 Defensive Assists", -5) { FoulAssistModifier = true };
        public static ArmorModifier DirtyPlayer = new ArmorModifier("Dirty Player", 1) { FoulAssistModifier = false };
        public static ArmorModifier Stakes = new ArmorModifier("Stakes", 1) { FoulAssistModifier = false };
        public static ArmorModifier Chainsaw = new ArmorModifier("Chainsaw", 3) { FoulAssistModifier = false };
        public static ArmorModifier Foul = new ArmorModifier("Foul", 1) { FoulAssistModifier = false };
  }

  public static class ArmorModifierExtensions
  {
    private static readonly Dictionary<string, ArmorModifier> ArmorModifiers = new Dictionary<string, ArmorModifier>();

    static ArmorModifierExtensions()
    {
      ArmorModifiers = new Dictionary<string, ArmorModifier>()
      {
        ["Claws"] = ArmorModifier.Claws,
        ["Mighty Blow"] = ArmorModifier.MightyBlow,
        ["1 Offensive Assist"] = ArmorModifier.OffensiveAssist1,
        ["2 Offensive Assists"] = ArmorModifier.OffensiveAssist2,
        ["3 Offensive Assists"] = ArmorModifier.OffensiveAssist3,
        ["4 Offensive Assists"] = ArmorModifier.OffensiveAssist4,
        ["5 Offensive Assists"] = ArmorModifier.OffensiveAssist5,
        ["6 Offensive Assists"] = ArmorModifier.OffensiveAssist6,
        ["7 Offensive Assists"] = ArmorModifier.OffensiveAssist7,
        ["1 Defensive Assist"] = ArmorModifier.DefensiveAssist1,
        ["2 Defensive Assists"] = ArmorModifier.DefensiveAssist2,
        ["3 Defensive Assists"] = ArmorModifier.DefensiveAssist3,
        ["4 Defensive Assists"] = ArmorModifier.DefensiveAssist4,
        ["5 Defensive Assists"] = ArmorModifier.DefensiveAssist5,
        ["Dirty Player"] = ArmorModifier.DirtyPlayer,
        ["Stakes"] = ArmorModifier.Stakes,
        ["Chainsaw"] = ArmorModifier.Chainsaw,
        ["Foul"] = ArmorModifier.Foul
      };
    }

    public static ArmorModifier AsArmorModifier(this FFBEnumeration ffbEnum)
    {
      return ArmorModifiers.ContainsKey(ffbEnum.key) ? ArmorModifiers[ffbEnum.key] : null;
    }
  }
  
}