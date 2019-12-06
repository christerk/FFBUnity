using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Fumbbl.Model
{
    public class FfbEnumerationFactory
    {
        public string Name { get; set; }

        public FfbEnumerationFactory(string name)
        {
            Name = name;

            RegisterModifier(name, this);
        }

        protected void RegisterModifier(string key, FfbEnumerationFactory obj)
        {
            FfbEnumerationFactoryExtension.RegisterModifier(GetType(), key, obj);
        }
    }

    public static class FfbEnumerationFactoryExtension
    {
        private static readonly Dictionary<Type, Dictionary<string, FfbEnumerationFactory>> Enumerations = new Dictionary<Type, Dictionary<string, FfbEnumerationFactory>>();

        static FfbEnumerationFactoryExtension()
        {
            Enumerations = new Dictionary<Type, Dictionary<string, FfbEnumerationFactory>>();
        }

        public static void RegisterModifier(Type type, string key, FfbEnumerationFactory modifier)
        {
            if (!Enumerations.ContainsKey(type))
            {
                Enumerations.Add(type, new Dictionary<string, FfbEnumerationFactory>());
            }

            Enumerations[type].Add(key, modifier);
        }

        public static T As<T>(this FFBEnumeration ffbEnum)
            where T : FfbEnumerationFactory
        {
            if ((ffbEnum is null) || (ffbEnum.key is null)){
                return null;
            }
            if (!Enumerations.ContainsKey(typeof(T)))
            {
                // The static initializers of the class may not have run, so let's force them to do so.
                RuntimeHelpers.RunClassConstructor(typeof(T).TypeHandle);
            }
            return Enumerations[typeof(T)].ContainsKey(ffbEnum.key) ? (T)Enumerations[typeof(T)][ffbEnum.key] : null;
        }
    }
}
