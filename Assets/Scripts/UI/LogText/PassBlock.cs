using System.Collections.Generic;

namespace Fumbbl.UI.LogText
{
    public class PassBlock : LogTextGenerator<Ffb.Dto.Reports.PassBlock>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.PassBlock report)
        {
            if (!report.passBlockAvailable)
            {
                var colour = report.teamId == FFB.Instance.Model.TeamHome.Id ? "#ff0000" : "#0000ff";
                yield return new LogRecord($"<{colour}No pass blockers in range to intercept.</color>");
            }
        }
    }
}
