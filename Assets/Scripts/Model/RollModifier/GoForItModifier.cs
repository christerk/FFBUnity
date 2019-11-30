using System.Collections.Generic;

namespace Fumbbl.Model.RollModifier
{
    public class GoForItModifier : AbstractModifier
    {
        public GoForItModifier(string name, int modifier) : base(name, modifier) { }

        public static GoForItModifier Blizzard = new GoForItModifier("Blizzard", 1);
        public static GoForItModifier GreasedShoes = new GoForItModifier("Greased Shoes", 3);
    }
}