
using Fumbbl.Dto;
using Fumbbl.Dto.Reports;
using Fumbbl.UI;
using Fumbbl.UI.LogText;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Fumbbl.Model
{
    internal class ModelChangeFactory
    {
        private Dictionary<Type, IModelUpdater> GeneratorClasses;

        public ModelChangeFactory()
        {
            GeneratorClasses = new Dictionary<Type, IModelUpdater>();

            var generators = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.GetInterfaces().Contains(typeof(IModelUpdater)));

            foreach (var generator in generators)
            {
                var attr = generator.CustomAttributes.Where(a => a.AttributeType == typeof(ModelChangeAttribute)).SingleOrDefault();

                if (attr != null)
                {
                    var key = (Type)attr.ConstructorArguments[0].Value;
                    GeneratorClasses.Add(key, (IModelUpdater)generator.GetConstructor(new Type[] { }).Invoke(new object[] { }));
                }
            }
        }

        internal IModelUpdater Create(Dto.IModelChange modelChange)
        {
            Type t = modelChange.GetType();

            if (GeneratorClasses.ContainsKey(t))
            {
                return GeneratorClasses[modelChange.GetType()];
            }
            return null;
        }
    }
}