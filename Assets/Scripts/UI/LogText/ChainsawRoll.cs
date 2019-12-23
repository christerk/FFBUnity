using Fumbbl.Model.Types;
using System.Collections.Generic;

namespace Fumbbl.UI.LogText
{
    public class ChainsawRoll : LogTextGenerator<Ffb.Dto.Reports.ChainsawRoll>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.ChainsawRoll report)
        {
            Player player = FFB.Instance.Model.GetPlayer(report.playerId);

            yield return new LogRecord($"<b>Chainsaw Roll [ {report.roll} ]</b>");

            if (report.successful)
            {
                yield return new LogRecord($"{player.FormattedName} uses {player.Gender.Genetive} Chainsaw.", 1);
            }
            else
            {
                yield return new LogRecord($"{player.FormattedName}'s Chainsaw kicks back to hurt {player.Gender.Dative}.", 1);
            }
        }
    }
}
