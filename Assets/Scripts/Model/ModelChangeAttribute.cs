using System;

namespace Fumbbl.Model
{
    internal class ModelChangeAttribute : Attribute
    {
        public Type ModelChangeType { get; }
        public ModelChangeAttribute(Type reportType)
        {
            ModelChangeType = reportType;
        }
    }
}