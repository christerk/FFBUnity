using Fumbbl.Model.Types;
using System.Collections.Generic;

namespace Fumbbl.UI.LogText
{
    public class PlayCard : LogTextGenerator<Ffb.Dto.Reports.PlayCard>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.PlayCard report)
        {
            Team team = FFB.Instance.Model.GetTeam(report.teamId);

            if(report.playerId.Length != 0)
            {
                Player player = FFB.Instance.Model.GetPlayer(report.playerId);
                yield return new LogRecord($"{team.FormattedName} plays the card {report.card} on {player.FormattedName}.");
            }
            else
            {
                yield return new LogRecord($"{team.FormattedName} plays the card {report.card}.");
            }
           
        }
    }
}
