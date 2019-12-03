using Fumbbl.Model.Types;
using System.Collections.Generic;

namespace Fumbbl.UI.LogText
{
    public class BribesRoll : LogTextGenerator<Ffb.Dto.Reports.BribesRoll>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.BribesRoll report)
        {
            Player player = FFB.Instance.Model.GetPlayer(report.playerId);

            yield return new LogRecord($"<b>Bribes Roll [ {report.roll} ]</b>");

            if (report.successful)
            {
                yield return new LogRecord($"The ref refrains from penalizing {player.FormattedName} and {player.Gender.Nominative} remains in the game.", 1);
            }
            else
            {
                yield return new LogRecord($"The ref appears to be unimpressed and {player.FormattedName} must leave the game.", 1);
            }
        }
    }
}
