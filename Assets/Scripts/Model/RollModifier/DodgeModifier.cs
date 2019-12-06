namespace Fumbbl.Model.RollModifier
{
    public class DodgeModifier : AbstractModifier
    {
        public DodgeModifier(string name, int modifier) : base(name, modifier) { }

        public static DodgeModifier Stunty = new DodgeModifier("Stunty", 0) {ShowModifierSign = ShowModifierSignMode.Hidden, ShowModifier = false, ShowName = false};
        public static DodgeModifier BreakTackle = new DodgeModifier("Break Tackle", 0) {ShowModifierSign = ShowModifierSignMode.Hidden, ShowModifier = false, ShowName = false};
        public static DodgeModifier TwoHeads = new DodgeModifier("Two Heads", -1) { };
        public static DodgeModifier DivingTackle = new DodgeModifier("Diving Tackle", 2) { };
        public static DodgeModifier Titchy = new DodgeModifier("Titchy", -1) { };
        public static DodgeModifier Tacklezone1 = new DodgeModifier("1 Tacklezone", 1) {ShowModifier = false};
        public static DodgeModifier Tacklezone2 = new DodgeModifier("2 Tacklezones", 2) {ShowModifier = false};
        public static DodgeModifier Tacklezone3 = new DodgeModifier("3 Tacklezones", 3) {ShowModifier = false};
        public static DodgeModifier Tacklezone4 = new DodgeModifier("4 Tacklezones", 4) {ShowModifier = false};
        public static DodgeModifier Tacklezone5 = new DodgeModifier("5 Tacklezones", 5) {ShowModifier = false};
        public static DodgeModifier Tacklezone6 = new DodgeModifier("6 Tacklezones", 6) {ShowModifier = false};
        public static DodgeModifier Tacklezone7 = new DodgeModifier("7 Tacklezones", 7) {ShowModifier = false};
        public static DodgeModifier Tacklezone8 = new DodgeModifier("8 Tacklezones", 8) {ShowModifier = false};
        public static DodgeModifier PrehensileTail1 = new DodgeModifier("1 Prehensile Tail", 1) {ShowModifier = false};
        public static DodgeModifier PrehensileTail2 = new DodgeModifier("2 Prehensile Tails", 2) {ShowModifier = false};
        public static DodgeModifier PrehensileTail3 = new DodgeModifier("3 Prehensile Tails", 3) {ShowModifier = false};
        public static DodgeModifier PrehensileTail4 = new DodgeModifier("4 Prehensile Tails", 4) {ShowModifier = false};
        public static DodgeModifier PrehensileTail5 = new DodgeModifier("5 Prehensile Tails", 5) {ShowModifier = false};
        public static DodgeModifier PrehensileTail6 = new DodgeModifier("6 Prehensile Tails", 6) {ShowModifier = false};
        public static DodgeModifier PrehensileTail7 = new DodgeModifier("7 Prehensile Tails", 7) {ShowModifier = false};
        public static DodgeModifier PrehensileTail8 = new DodgeModifier("8 Prehensile Tails", 8) {ShowModifier = false};
    }
}