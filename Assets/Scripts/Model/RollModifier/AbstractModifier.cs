using System;

namespace Fumbbl.Model.RollModifier
{

    public enum ShowModifierSignMode
    {
        ShowReversed = -1,
        Hidden = 0,
        ShowNormal = 1
    }

    public abstract class AbstractModifier : FfbEnumerationFactory
    {
        public int Modifier { get; set; }
        public virtual ShowModifierSignMode ShowModifierSign { get; set; } = ShowModifierSignMode.ShowNormal;
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

                if (ShowModifierSign == ShowModifierSignMode.ShowNormal)
                {
                    sign = (Modifier <= 0 ? " +" : " -");
                }
                else if (ShowModifierSign == ShowModifierSignMode.ShowReversed)
                {
                    sign = (0 <= Modifier ? " +" : " -");
                }

                return $"{sign}{modifier}{name}";
            }
        }
    }
}
