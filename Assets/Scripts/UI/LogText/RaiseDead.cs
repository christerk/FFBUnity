using Fumbbl.Model.Types;
using System.Collections.Generic;

namespace Fumbbl.UI.LogText
{
    public class RaiseDead : LogTextGenerator<Ffb.Dto.Reports.RaiseDead>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.RaiseDead report)
        {
            Player player = FFB.Instance.Model.GetPlayer(report.playerId);
            Team joiningTeam = player.Team.IsHome == true ? FFB.Instance.Model.TeamAway : FFB.Instance.Model.TeamHome;

            if(report.nurglesRot)
            {
                yield return new LogRecord($" {player.FormattedName} has been infected with Nurgle's Rot and will join team {joiningTeam.FormattedName} as a Rotter in the next game.");
            }
            else
            {
                yield return new LogRecord($" {player.FormattedName} is raised from the dead to join team {joiningTeam.FormattedName} as a Zombie.");
            }
        }
    }
}
