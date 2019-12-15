using System.Collections.Generic;

namespace Fumbbl.UI.LogText
{
    public class PassBlock : LogTextGenerator<Ffb.Dto.Reports.PassBlock>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.PassBlock report)
        {
            if (!report.passBlockAvailable)
            {
                bool IsHome = (report.teamId == FFB.Instance.Model.TeamHome.Id);
                var colorsettings = FFB.Instance.Settings.Color;
                string color = IsHome ? colorsettings.HomeColor : colorsettings.AwayColor;
                yield return new LogRecord($"<color={color}>No pass blockers in range to intercept.</color>");
            }
        }
    }
}
