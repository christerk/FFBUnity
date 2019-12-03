using Fumbbl.Model.Types;
using System.Collections.Generic;

namespace Fumbbl.UI.LogText
{
    public class AnimosityRoll : LogTextGenerator<Ffb.Dto.Reports.AnimosityRoll>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.AnimosityRoll report)
        {
            Player player = FFB.Instance.Model.GetPlayer(FFB.Instance.Model.ActingPlayer.PlayerId);

            yield return new LogRecord($"<b>Animosity Roll [ {report.roll} ]</b>");

            if (report.successful)
            {
                yield return new LogRecord($"{player.FormattedName} resists {player.Gender.Genetive} Animosity.", 1);
                yield return new LogRecord($"Succeeded on a roll of {report.minimumRoll}+", 1);
            }
            else
            {
                yield return new LogRecord($"{player.FormattedName} gives in to {player.Gender.Genetive} Animosity.", 1);
                yield return new LogRecord($"Roll a {report.minimumRoll}+ to succeed", 1);
            }
        }
    }
}
