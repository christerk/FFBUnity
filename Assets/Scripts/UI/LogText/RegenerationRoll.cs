using Fumbbl.Model.Types;
using System.Collections.Generic;

namespace Fumbbl.UI.LogText
{
    public class RegenerationRoll : LogTextGenerator<Ffb.Dto.Reports.RegenerationRoll>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.RegenerationRoll report)
        {
            if (report.roll > 0)
            {
                yield return new LogRecord($"<b>Regeneration Roll [ {report.roll} ]</b>");

                Player player = FFB.Instance.Model.GetPlayer(report.playerId);
                if (report.successful)
                {
                    yield return new LogRecord($"{player.FormattedName} regenerates.", 1);
                }
                else
                {
                    yield return new LogRecord($"{player.FormattedName} does not regenerate.", 1);
                }
            }
        }
    }
}
