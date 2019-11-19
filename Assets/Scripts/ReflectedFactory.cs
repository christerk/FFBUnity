using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Fumbbl
{
    public class ReflectedFactory<T, K>
        where T : class
    {
        protected Dictionary<K, Type> GeneratorClasses { get; }
        protected Dictionary<K, T> GeneratorInstances { get; }

        public ReflectedFactory(Type attributeType)
        {
            GeneratorClasses = new Dictionary<K, Type>();
            GeneratorInstances = new Dictionary<K, T>();

            var generators = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.GetInterfaces().Contains(typeof(T)));

            foreach (var generator in generators)
            {
                var attr = generator.CustomAttributes.Where(a => a.AttributeType == attributeType).SingleOrDefault();

                if (attr != null)
                {
                    var key = (K)attr.ConstructorArguments[0].Value;
                    GeneratorClasses.Add(key, generator);
                    GeneratorInstances.Add(key, (T)generator.GetConstructor(new Type[] { }).Invoke(new object[] { }));
                }
            }
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

        internal T DeserializeJson(dynamic jsonObject, K key)
        {
            Type t = GetReflectedClass(key);
            if (t != null)
            {
                T result = (T)JsonConvert.DeserializeObject(jsonObject.ToString(), t);
                return result;
            }
            return null;
        }
    }
}
