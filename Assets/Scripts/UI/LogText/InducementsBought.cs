using Fumbbl.Model.Types;
using System.Collections.Generic;

namespace Fumbbl.UI.LogText
{
    public class InducementsBought : LogTextGenerator<Ffb.Dto.Reports.InducementsBought>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.InducementsBought report)
        {
            Team team = FFB.Instance.Model.GetTeam(report.teamId);

            if(report.nrOfInducements == 0 && report.nrOfStars == 0 && report.nrOfMercenaries == 0)
            {
                yield return new LogRecord($"Team {team.FormattedName} buys no inducements.");
            }
            else
            {
                yield return new LogRecord($"<b>Team {team.FormattedName} buys:</b>");
                if(report.nrOfInducements > 0) yield return new LogRecord($"{report.nrOfInducements} Inducements", 1);
                if(report.nrOfStars > 0) yield return new LogRecord($"{report.nrOfStars} Stars", 1);
                if(report.nrOfMercenaries > 0) yield return new LogRecord($"{report.nrOfMercenaries} Mercenaries", 1);
                yield return new LogRecord($"For {report.gold} Gold", 1);
            }
          
        }
    }
}
