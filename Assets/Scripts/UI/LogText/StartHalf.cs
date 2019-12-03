using Fumbbl.Ffb.Dto;
using Fumbbl.Model;
using System.Collections.Generic;
using System.Linq;

namespace Fumbbl.UI.LogText
{
    public class StartHalf : LogTextGenerator<Ffb.Dto.Reports.StartHalf>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.StartHalf report)
        {
            string half;
            switch (report.half)
            {
                case 1: half = "first half"; break;
                case 2: half = "second half"; break;
                default: half = "overtime"; break;
            }
            yield return new LogRecord($"Starting {half}");
        }
    }
}
