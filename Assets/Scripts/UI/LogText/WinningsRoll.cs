using Fumbbl.Model.Types;
using System.Collections.Generic;

namespace Fumbbl.UI.LogText
{
    public class WinningsRoll : LogTextGenerator<Ffb.Dto.Reports.WinningsRoll>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.WinningsRoll report)
        {
            yield return new LogRecord($"<b>Winings Roll Home Team [{report.winningsRollHome}]</b>");
            yield return new LogRecord($"{FFB.Instance.Model.TeamHome.FormattedName} earn {report.winningsHome} gold coins");
            yield return new LogRecord($"<b>Winings Roll Away Team [{report.winningsRollAway}]</b>");
            yield return new LogRecord($"{FFB.Instance.Model.TeamAway.FormattedName} earn {report.winningsAway} gold coins");
        }

    }
}
