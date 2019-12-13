namespace Fumbbl.Model.RollModifier
{
    public class InjuryModifier : AbstractModifier
    {
        public InjuryModifier(string name, int modifier) : base(name, modifier) {
            SignMode = SignMode.Negative;
        }

        public static InjuryModifier MightyBlow = new InjuryModifier("Mighty Blow", 1);
        public static InjuryModifier DirtyPlayer = new InjuryModifier("Dirty Player", 1);
        public static InjuryModifier Stunty = new InjuryModifier("Stunty", 0) { SignMode = SignMode.Hidden, ShowModifier = false, ShowName = false };
        public static InjuryModifier ThickSkull = new InjuryModifier("Thick Skull", 0) { SignMode = SignMode.Hidden, ShowModifier = false, ShowName = false };
        public static InjuryModifier NigglingInjury1 = new InjuryModifier("1 Niggling Injury", 1) { ShowModifier = false };
        public static InjuryModifier NigglingInjury2 = new InjuryModifier("2 Niggling Injuries", 2) { ShowModifier = false };
        public static InjuryModifier NigglingInjury3 = new InjuryModifier("3 Niggling Injuries", 3) { ShowModifier = false };
        public static InjuryModifier NigglingInjury4 = new InjuryModifier("4 Niggling Injuries", 4) { ShowModifier = false };
        public static InjuryModifier NigglingInjury5 = new InjuryModifier("5 Niggling Injuries", 5) { ShowModifier = false };
    }
}