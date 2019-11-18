using Fumbbl.Dto.Reports;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fumbbl.Dto
{
    public class DtoFactory
    {
        private readonly Dictionary<string, Type> ReportClasses;
        private readonly Dictionary<string, Type> ModelChangeClasses;
        public DtoFactory()
        {
            ReportClasses = new Dictionary<string, Type>();
            ModelChangeClasses = new Dictionary<string, Type>();

            var classes = System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.GetInterfaces().Contains(typeof(IReport)));
            foreach (var instance in classes)
            {
                var attr = instance.CustomAttributes.Where(a => a.AttributeType == typeof(ProtocolIdAttribute)).SingleOrDefault();
                if (attr != null)
                {
                    var key = attr.ConstructorArguments[0].Value as string;
                    ReportClasses.Add(key, instance);
                }
            }

            classes = System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.GetInterfaces().Contains(typeof(IModelChange)));
            foreach (var instance in classes)
            {
                var attr = instance.CustomAttributes.Where(a => a.AttributeType == typeof(ProtocolIdAttribute)).SingleOrDefault();
                if (attr != null)
                {
                    var key = attr.ConstructorArguments[0].Value as string;
                    ModelChangeClasses.Add(key, instance);
                }
            }
        }

        public IReport CreateReport(dynamic jsonObject)
        {
            string key = jsonObject?.reportId?.ToString();

            if (ReportClasses.ContainsKey(key))
            {
                Type t = ReportClasses[key];
                var report = (IReport)JsonConvert.DeserializeObject(jsonObject.ToString(), t);
                return report;
            }
            return new RawString() { text = jsonObject.ToString() };
        }

        internal IModelChange CreateModelChange(dynamic jsonObject)
        {
            string key = jsonObject?.modelChangeId?.ToString();

            if (ModelChangeClasses.ContainsKey(key))
            {
                Type t = ModelChangeClasses[key];
                var modelChange = (IModelChange)JsonConvert.DeserializeObject(jsonObject.ToString(), t);
                return modelChange;
            }
            return null;
        }
    }
}
