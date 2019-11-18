using System;

namespace Fumbbl.UI.LogText
{
    internal class ReportTypeAttribute : Attribute
    {
        public Type ReportType { get; }
        public ReportTypeAttribute(Type reportType)
        {
            ReportType = reportType;
        }
    }
}