using Fumbbl.Model.Types;
using System.Collections.Generic;
using System.Linq;

namespace Fumbbl.UI.LogText
{
    public class Spectators : LogTextGenerator<Ffb.Dto.Reports.Spectators>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.Spectators report)
        {
            yield return new LogRecord($"<b>Spectator Roll Home Team {CreateRollString(report.spectatorRollHome)}</b>");
            yield return new LogRecord($"Rolled total of {SpectatorSumString(report.spectatorRollHome)}.", 1);
            yield return new LogRecord($"{report.spectatorsHome} fans have come to support {FFB.Instance.Model.TeamHome.FormattedName}.", 1);

            yield return new LogRecord($"<b>Spectator Roll Away Team {CreateRollString(report.spectatorRollAway)}</b>");
            yield return new LogRecord($"Rolled total of {SpectatorSumString(report.spectatorRollAway)}.", 1);
            yield return new LogRecord($"{report.spectatorsAway} fans have come to support {FFB.Instance.Model.TeamAway.FormattedName}.", 1);

            if(report.fameHome > report.fameAway)
            {
                yield return new LogRecord($"<b>{FFB.Instance.Model.TeamHome.FormattedName} have a fan advantage (FAME + {report.fameHome}).</b>", 1);
            }
            else
            if(report.fameAway > report.fameHome)
            {
                yield return new LogRecord($"<b>{FFB.Instance.Model.TeamAway.FormattedName} have a fan advantage (FAME + {report.fameHome}).</b>", 1);
            }
            else
            {
                yield return new LogRecord($"<b>Both teams have equal fans</b>");
            }
        }

        private string SpectatorSumString(int[] rolls)
        {
            return $"{string.Join(",", rolls)} Fan Factor = {rolls.Sum()}";
        }
    }
}
