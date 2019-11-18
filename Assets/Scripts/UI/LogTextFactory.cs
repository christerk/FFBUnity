
using Fumbbl.Dto;
using Fumbbl.Dto.Reports;
using Fumbbl.UI;
using Fumbbl.UI.LogText;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

internal class LogTextFactory
{
    private Dictionary<Type, ILogTextGenerator> GeneratorClasses;

    public LogTextFactory()
    {
        GeneratorClasses = new Dictionary<Type, ILogTextGenerator>();

        var generators = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.GetInterfaces().Contains(typeof(ILogTextGenerator)));

        foreach (var generator in generators)
        {
            var attr = generator.CustomAttributes.Where(a => a.AttributeType == typeof(ReportTypeAttribute)).SingleOrDefault();

            if (attr != null)
            {
                var key = (Type)attr.ConstructorArguments[0].Value;
                GeneratorClasses.Add(key, (ILogTextGenerator)generator.GetConstructor(new Type[] { }).Invoke(new object[] { }));
            }
        }
    }

    internal string GetTextForReport(IReport report)
    {
        Type t = report.GetType();

        if (GeneratorClasses.ContainsKey(t))
        {
            return GeneratorClasses[report.GetType()].Convert(report);
        }
        return null;
    }
}