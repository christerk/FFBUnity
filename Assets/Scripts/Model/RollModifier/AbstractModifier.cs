using System;

namespace Fumbbl.Model.RollModifier
{
    public abstract class AbstractModifier : FfbEnumerationFactory
    {
        public int Modifier { get; set; }
        public bool ForcedModifiedString { get; set; } = false;

        public AbstractModifier(string name, int modifier) : base(name)
        {
            Name = name;
            Modifier = modifier;
        }


        public virtual bool ModifierIncludedInName => false;
        public virtual bool ReversedModifier => false;

        public string ModifierString
        {
            get
            {
                if (Modifier == 0)
                {
                    if (!ForcedModifiedString)
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return $" {Name}";
                    }

                }

                string sign;
                if (!ReversedModifier)
                {
                    sign = (Modifier <= 0 ? "+" : "-");
                }
                else
                {
                    sign = (0 <= Modifier ? "+" : "-");
                }
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
