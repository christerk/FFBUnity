using Fumbbl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fumbbl.Model.RollModifier
{
    public abstract class AbstractModifier
    {
        public string Name { get; set; }
        public int Modifier { get; set; }

        public AbstractModifier(string name, int modifier)
        {
            Name = name;
            Modifier = modifier;

            RegisterModifier(name, this);
        }

        public virtual bool ModifierIncludedInName => false;

        private void RegisterModifier(string key, AbstractModifier modifier)
        {
            AbstractModifierExtension.RegisterModifier(GetType(), key, modifier);
        }

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
                    return $" {sign} {Modifier} {Name}";
                }
            }
        }
    }

    public static class AbstractModifierExtension
    {
        private static readonly Dictionary<Type, Dictionary<string, AbstractModifier>> Modifiers = new Dictionary<Type, Dictionary<string, AbstractModifier>>();

        static AbstractModifierExtension()
        {
            Modifiers = new Dictionary<Type, Dictionary<string, AbstractModifier>>();
        }

        public static void RegisterModifier(Type type, string key, AbstractModifier modifier)
        {
            if (!Modifiers.ContainsKey(type))
            {
                Modifiers.Add(type, new Dictionary<string, AbstractModifier>());
            }

            Modifiers[type].Add(key, modifier);
        }

        public static T As<T>(this FFBEnumeration ffbEnum)
            where T : AbstractModifier
        {
            return Modifiers[typeof(T)].ContainsKey(ffbEnum.key) ? (T)Modifiers[typeof(T)][ffbEnum.key] : null;
        }

    }
}
