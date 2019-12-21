using Fumbbl.Model.Types;
using System.Collections.Generic;

namespace Fumbbl.UI.LogText
{
    public class CardsBought : LogTextGenerator<Ffb.Dto.Reports.CardsBought>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.CardsBought report)
        {
            Team team = FFB.Instance.Model.GetTeam(report.teamId);
            if(report.nrOfCards > 0)
            {
                string cardString = report.nrOfCards == 1 ? "card" : "cards";
                yield return new LogRecord($"Team {team.FormattedName} buys {report.nrOfCards} {cardString} for {report.gold} gold total.");
            }
            else
            {
                yield return new LogRecord($"Team {team.FormattedName} buys no cards.");
            }
        }
    }
}
