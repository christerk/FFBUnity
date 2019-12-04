using Fumbbl.Ffb.Dto;
using Fumbbl.Model;
using Fumbbl.Model.Types;
using System.Collections.Generic;
using System.Linq;

namespace Fumbbl.UI.LogText
{
    public class Leader : LogTextGenerator<Ffb.Dto.Reports.Leader>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.Leader report)
        {
            Team team = FFB.Instance.Model.GetTeam(report.teamId);

            if (string.Equals(report.leaderState, "available"))
            {
                yield return new LogRecord($"{team.FormattedName} gain a Leader re-roll.", 1);
            }
            else
            {
                yield return new LogRecord($"Leader re-roll removed from {team.FormattedName}.", 1);
            }
        }
    }
}
