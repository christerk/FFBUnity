using Fumbbl.Dto;
using System;

namespace Fumbbl.UI
{
    public abstract class LogTextGenerator : ReflectedGenerator<Type>
    {
        public LogTextGenerator(Type t) : base(t) { }

        public abstract string Convert(Report report);
    }
}