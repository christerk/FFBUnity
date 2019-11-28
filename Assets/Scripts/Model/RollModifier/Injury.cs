using System.Collections.Generic;

namespace Fumbbl.Model
{
    public class InjuryModifier
    {
        public string Name { get; set; }
        public int Modifier { get; set; }
        public boolean NigglingInjuryModifier { get; set; }
    }

    public static class InjuryModifierExtensions
    {
        private static readonly Dictionary<string, InjuryModifier> InjuryModifiers = new Dictionary<string, InjuryModifier>();

        static InjuryModifierExtensions()
        {
            InjuryModifiers = new Dictionary<string, InjuryModifier>()
            {
                ["Mighty Blow"] = new InjuryModifier() { Name = "Mighty Blow", Modifier = 1, NigglingInjuryModifier = false},
                ["Dirty Player"] = new InjuryModifier() { Name = "Dirty Player", Modifier = 1, NigglingInjuryModifier = false},
                ["Stunty"] = new InjuryModifier() { Name = "Stunty", Modifier = 0, NigglingInjuryModifier = false},
                ["Thick Skull"] = new InjuryModifier() { Name = "Thick Skull", Modifier = 0, NigglingInjuryModifier = false},
                ["1 Niggling Injury"] = new InjuryModifier() { Name = "1 Niggling Injury", Modifier = 1, NigglingInjuryModifier = true},
                ["2 Niggling Injuries"] = new InjuryModifier() { Name = "2 Niggling Injuries", Modifier = 2, NigglingInjuryModifier = true},
                ["3 Niggling Injuries"] = new InjuryModifier() { Name = "3 Niggling Injuries", Modifier = 3, NigglingInjuryModifier = true},
                ["4 Niggling Injuries"] = new InjuryModifier() { Name = "4 Niggling Injuries", Modifier = 4, NigglingInjuryModifier = true},
                ["5 Niggling Injuries"] = new InjuryModifier() { Name = "5 Niggling Injuries", Modifier = 5, NigglingInjuryModifier = true}
            }
        }

        public static InjuryModifier AsInjuryModifier(this FFBEnumeration ffbEnum)
        {
            return InjuryModifiers.ContainsKey(ffbEnum.key) ? InjuryModifiers[ffbEnum.key] : null;
        }
 }