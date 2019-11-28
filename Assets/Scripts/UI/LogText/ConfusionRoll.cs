using Fumbbl.Model;
using Fumbbl.Model.Types;
using System.Collections.Generic;

namespace Fumbbl.UI.LogText
{
    public class ConfusionRoll : LogTextGenerator<Ffb.Dto.Reports.ConfusionRoll>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.ConfusionRoll report)
        {
            yield return new LogRecord($"{report.confusionSkill} Roll [ {report.roll} ]");

            Player player = FFB.Instance.Model.GetPlayer(FFB.Instance.Model.ActingPlayer.PlayerId);

            if (report.successful)
            {
                yield return new LogRecord($"{player.FormattedName} is able to act normally.", 1);
            }
            else
            {
                if (report.confusionSkill == "Wild Animal")
                {
                    yield return new LogRecord($"{player.FormattedName} roars in rage.", 1);
                }
                else if (report.confusionSkill == "Take Root")
                {
                    yield return new LogRecord($"{player.FormattedName} takes root.", 1);
                }
                else
                {
                    yield return new LogRecord($"{player.FormattedName} is confused.", 1);
                }
            }

            if (true) // showModifiersOnSuccess / showModifiersOnFailure
            {
                if (report.successful)
                {
                    yield return new LogRecord($"Succeeded on a roll of {report.minimumRoll}+", 1);
                }
                else
                {
                    yield return new LogRecord($"Roll a {report.minimumRoll}+ to succeed.", 1);
                }
            }
        }
    }
}
