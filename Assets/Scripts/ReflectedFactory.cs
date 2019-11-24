using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Fumbbl
{
    public class ReflectedFactory<T, K>
        where T : class, IReflectedObject<K>
    {
        protected Dictionary<K, Type> GeneratorClasses { get; }
        protected Dictionary<K, T> GeneratorInstances { get; }

        public ReflectedFactory()
        {
            GeneratorClasses = new Dictionary<K, Type>();
            GeneratorInstances = new Dictionary<K, T>();

            var generators = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => typeof(T).IsAssignableFrom(t) && !t.IsAbstract)
                .ToList();

            if (generators.Count() == 0 && typeof(T).IsGenericType)
            {
                var a = typeof(T).GenericTypeArguments[0];

                generators = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => !t.IsAbstract 
                    && t.BaseType != null 
                    && t.BaseType.IsGenericType 
                    && !t.ContainsGenericParameters
                    && typeof(IReflectedObject<K>).IsAssignableFrom(t) 
                    && a.IsAssignableFrom(t.BaseType.GenericTypeArguments[0]))
                .ToList();
            }

            foreach (var generator in generators)
            {
                object o = Activator.CreateInstance(generator);
                MethodInfo method = o.GetType().GetMethod("GetReflectedKey");
                object result = method.Invoke(o, new object[] { });

                T instance;
                K key;

                method = o.GetType().GetMethod("AsGenericGenerator");
                if (method != null)
                {
                    instance = (T) method.Invoke(o, new object[] { });
                    key = (K)result;
                }
                else
                {
                    instance = (T)o;
                    key = instance.GetReflectedKey();
                }
                GeneratorClasses.Add(key, generator);
                GeneratorInstances.Add(key, instance);
            }
        }

        private static bool IsAssignableToGenericType(Type givenType, Type genericType)
        {
            var interfaceTypes = givenType.GetInterfaces();

            foreach (var it in interfaceTypes)
            {
                if (it.IsGenericType && it.GetGenericTypeDefinition() == genericType)
                    return true;
            }

            if (givenType.IsGenericType && givenType.GetGenericTypeDefinition() == genericType)
                return true;

            Type baseType = givenType.BaseType;
            if (baseType == null) return false;

            return IsAssignableToGenericType(baseType, genericType);
        }
        internal Type GetReflectedClass(K key)
        {
            if (GeneratorClasses.ContainsKey(key))
            {
                return GeneratorClasses[key];
            }
            return null;
        }

        internal T GetReflectedInstance(K key)
        {
            if (GeneratorInstances.ContainsKey(key))
            {
                return (T)GeneratorInstances[key];
            }
            return null;
        }

        internal T DeserializeJson(JToken jsonObject, K key)
        {
            Type t = GetReflectedClass(key);
            if (t != null)
            {
                T result = (T) jsonObject.ToObject(t);
                return result;
            }
            return null;
        }
    }
}
