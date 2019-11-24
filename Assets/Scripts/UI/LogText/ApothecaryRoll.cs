using Fumbbl.Ffb.Dto;
using Fumbbl.Model;
using System.Collections.Generic;
using System.Linq;

namespace Fumbbl.UI.LogText
{
    public class ApothecaryRoll : LogTextGenerator<Ffb.Dto.Reports.ApothecaryRoll>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.ApothecaryRoll report)
        {
            if (report.casualtyRoll.Length > 0)
            {
                Player player = FFB.Instance.Model.GetPlayer(report.playerId);
                string injuryDescription = Injury.GetDescription(report.playerState);
                yield return new LogRecord("Apothecary used.");
                yield return new LogRecord($"Casualty Roll [ {report.casualtyRoll[0]} ][ {report.casualtyRoll[1]} ]");
                yield return new LogRecord($"{player.FormattedName} {injuryDescription}.", 1);
                if (report.seriousInjury != null)
                {
                    yield return new LogRecord($"{player.FormattedName} {report.seriousInjury}.", 1);
                }
            }
        }
    }
}
