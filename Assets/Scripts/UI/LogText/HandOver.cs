using Fumbbl.Model.Types;
using System.Collections.Generic;

namespace Fumbbl.UI.LogText
{
    public class HandOver : LogTextGenerator<Ffb.Dto.Reports.HandOver>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.HandOver report)
        {
            Player thrower = FFB.Instance.Model.GetPlayer(FFB.Instance.Model.ActingPlayer.PlayerId);
            Player catcher = FFB.Instance.Model.GetPlayer(report.catcherId);
            yield return new LogRecord($"{thrower.FormattedName} hands over the ball to {catcher.FormattedName}:");
        }
    }
}
