using Fumbbl.Model;
using System.Collections.Generic;

namespace Fumbbl.UI.LogText
{
    public class KickoffResult : LogTextGenerator<Ffb.Dto.Reports.KickoffResult>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.KickoffResult report)
        {
            yield return new LogRecord($"<b>Kick-off Event Roll {CreateRollString(report.kickoffRoll)}</b>");
            var result = report.kickoffResult.As<Model.Types.KickoffResult>();
            yield return new LogRecord($"Kick-off event is {result.Title}", 1);
            yield return new LogRecord(result.Description, 1);
        }
    }
}
