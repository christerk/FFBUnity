using Fumbbl.Model.Types;
using System.Collections.Generic;

namespace Fumbbl.UI.LogText
{
    public class TimeoutEnforced : LogTextGenerator<Ffb.Dto.Reports.TimeoutEnforced>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.TimeoutEnforced report)
        {
            yield return new LogRecord($"Coach {report.coach} forces a timeout.");
        }
    }
}
