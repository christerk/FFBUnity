using System.Collections.Generic;

namespace Fumbbl.UI.LogText
{
    public class KickoffScatter : LogTextGenerator<Ffb.Dto.Reports.KickoffScatter>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.KickoffScatter report)
        {
            yield return new LogRecord($"<b>Kick-off Scatter Roll [ {report.rollScatterDirection} ][ {report.rollScatterDistance} ]</b>");
            string squares = report.rollScatterDistance != 1 ? "squares" : "square";
            string direction = report.scatterDirection;
            yield return new LogRecord($"The kick will land {report.rollScatterDistance} {squares} {direction} of where it was aimed.", 1);
        }
    }
}
