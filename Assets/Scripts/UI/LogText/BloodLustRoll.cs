using Fumbbl.Model.Types;
using System.Collections.Generic;

namespace Fumbbl.UI.LogText
{
    public class BloodLustRoll : LogTextGenerator<Ffb.Dto.Reports.BloodLustRoll>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.BloodLustRoll report)
        {
            Player player = FFB.Instance.Model.GetPlayer(FFB.Instance.Model.ActingPlayer.PlayerId);

            yield return new LogRecord($"<b>Blood Lust Roll [ {report.roll} ]</b>");

            if (report.successful)
            {
                yield return new LogRecord($"{player.FormattedName} resists the Blood Lust.", 1);
                yield return new LogRecord($"Succeeded on a roll of {report.minimumRoll}+", 1);
            }
            else
            {
                yield return new LogRecord($"{player.FormattedName} gives in to the Blood Lust.", 1);
                yield return new LogRecord("Player must feed at the end of the action or leave the pitch and suffer a turnover.", 1);
                yield return new LogRecord($"Roll a {report.minimumRoll}+ to succeed", 1);
            }
        }
    }
}
