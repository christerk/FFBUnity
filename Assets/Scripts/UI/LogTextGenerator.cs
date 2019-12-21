using Fumbbl.Ffb.Dto;
using System;
using System.Collections.Generic;

namespace Fumbbl.UI
{
    public abstract class LogTextGenerator<T> : ReflectedGenerator<Type>
        where T : Report
    {
        public LogTextGenerator() : base(typeof(T)) { }

        public LogTextGenerator<Report> AsGenericGenerator()
        {
            return this.CastGenerator<T, Report>();
        }

        public IEnumerable<LogRecord> HandleReport(Report report)
        {
            return Convert((T)report);
        }

        public static string CreateRollString(int[] rolls)
        {
            return $"[ {string.Join(" ][ ", rolls)} ]";
        }

        public abstract IEnumerable<LogRecord> Convert(T report);
    }

    internal class CastedLogTextGenerator<TTo, TFrom> : LogTextGenerator<TTo>
        where TTo : Report
        where TFrom : Report
    {
        private readonly LogTextGenerator<TFrom> Generator;

        public CastedLogTextGenerator(LogTextGenerator<TFrom> generator)
        {
            Generator = generator;
        }

        public override IEnumerable<LogRecord> Convert(TTo report)
        {
            return Generator.Convert(report as TFrom);
        }
    }

    public static class LogTextExtensions
    {
        public static LogTextGenerator<TTo> CastGenerator<TFrom, TTo>(this LogTextGenerator<TFrom> generator)
            where TTo : Report
            where TFrom : Report
        {
            return new CastedLogTextGenerator<TTo, TFrom>(generator);
        }
    }
}
