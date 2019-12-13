using System.Collections.Generic;
using System.Linq;

namespace Fumbbl.UI.LogText
{
    public class ScatterBallRoll : LogTextGenerator<Ffb.Dto.Reports.ScatterBall>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.ScatterBall report)
        {
            string reportstr = report.rolls.Length == 1 ? "Scatter Roll [ " : "Scatter Rolls [ ";
            reportstr += string.Join(", ", report.rolls.Select(x=>x.ToString()).ToArray());
            reportstr += " ] ";
            reportstr += string.Join(", ", report.directionArray);
            yield return new LogRecord($"<b>{reportstr}</b>");
        }
    }
}
