using System;

namespace Fumbbl
{
    internal class ContextSwitcher : IDisposable
    {
        public FFB.ReportModeType ReportMode { get; set; }

        public ContextSwitcher()
        {
            ReportMode = FFB.Instance.ReportMode;
        }

        public void Dispose()
        {
            FFB.Instance.ReportMode = ReportMode;
        }
    }
}