using System;

namespace Fumbbl.Model.RollModifier
{
    public enum SignMode
    {
        Negative = -1,
        Hidden = 0,
        Positive = 1
    }

    public abstract class AbstractModifier : FfbEnumerationFactory
    {
        public int Modifier { get; set; }
        public SignMode SignMode { get; set; } = SignMode.Positive;
        public bool ShowModifier { get; set; } = true;
        public bool ShowName { get; set; } = true;

        public AbstractModifier(string name, int modifier) : base(name)
        {
            Name = name;
            Modifier = modifier;
        }

        public string ModifierString
        {
            get
            {
                string sign = string.Empty;
                string modifier = ShowModifier? $" {Math.Abs(Modifier)}":string.Empty;
                string name = ShowName? $" {Name}":string.Empty;

                if (SignMode == SignMode.Positive)
                {
                    sign = (Modifier <= 0 ? " +" : " -");
                }
                else if (SignMode == SignMode.Negative)
                {
                    sign = (0 <= Modifier ? " +" : " -");
                }

                return $"{sign}{modifier}{name}";
            }
        }
    }
}
