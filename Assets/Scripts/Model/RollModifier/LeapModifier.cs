namespace Fumbbl.Model.RollModifier
{
    public class LeapModifier : AbstractModifier
    {
        public LeapModifier(string name, int modifier) : base(name, modifier) { }

        public static LeapModifier VeryLongLegs = new LeapModifier("Very Long Legs", -1);
    }
}