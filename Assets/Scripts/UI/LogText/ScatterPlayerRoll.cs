using Fumbbl.Model.Types;
using System.Collections.Generic;
using System.Linq;

namespace Fumbbl.UI.LogText
{
    public class ScatterPlayerRoll : LogTextGenerator<Ffb.Dto.Reports.ScatterPlayer>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.ScatterPlayer report)
        {
            Coordinate startCoordinate = Coordinate.Create(report.startCoordinate);
            Coordinate endCoordinate = Coordinate.Create(report.endCoordinate);
            string reportstr = report.rolls.Length == 1 ? "Scatter Roll [ " : "Scatter Rolls [ ";
            reportstr += string.Join(", ", report.rolls.Select(x=>x.ToString()).ToArray());
            reportstr += " ] ";
            reportstr += string.Join(", ", report.directionArray);
            yield return new LogRecord($"<b>{reportstr}</b>");
            yield return new LogRecord($"Player scatters from square {startCoordinate} to square {endCoordinate}.", 1);
        }
    }
}
