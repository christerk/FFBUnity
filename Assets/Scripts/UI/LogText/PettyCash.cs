using Fumbbl.Model.Types;
using System.Collections.Generic;

namespace Fumbbl.UI.LogText
{
    public class PettyCash : LogTextGenerator<Ffb.Dto.Reports.PettyCash>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.PettyCash report)
        {
            Team team = FFB.Instance.Model.GetTeam(report.teamId);
            yield return new LogRecord($"Team {team.FormattedName} transfers {report.gold} gold from the Treasury into petty cash.");
        }
    }
}
