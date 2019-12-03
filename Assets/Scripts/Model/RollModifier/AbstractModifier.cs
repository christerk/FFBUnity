using System;

namespace Fumbbl.Model.RollModifier
{
    public abstract class AbstractModifier : FfbEnumerationFactory
    {
        public int Modifier { get; set; }

        public AbstractModifier(string name, int modifier) : base(name)
        {
            Name = name;
            Modifier = modifier;
        }

        public virtual bool ModifierIncludedInName => false;

        public string ModifierString
        {
            get
            {
                if (Modifier == 0)
                {
                    return string.Empty;
                }

                string sign = Modifier > 0 ? "+" : "-";
                if (ModifierIncludedInName)
                {
                    return $" {sign} {Name}";
                }
                else
                {
                    return $" {sign} {Math.Abs(Modifier)} {Name}";
                }
            }
        }
    }
}
