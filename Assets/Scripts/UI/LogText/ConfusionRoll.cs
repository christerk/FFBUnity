using Assets.Scripts.Model;
using Fumbbl.Ffb.Dto;
using Fumbbl.Model;
using System.Collections.Generic;
using System.Linq;

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
                yield return new LogRecord($"{player.FormattedName} is able to act normally.");
            }
            else
            {
                if (report.confusionSkill == "Wild Animal")
                {
                    yield return new LogRecord($"{player.FormattedName} roars in rage.");
                }
                else if (report.confusionSkill == "Take Root")
                {
                    yield return new LogRecord($"{player.FormattedName} takes root.");
                }
                else
                {
                    yield return new LogRecord($"{player.FormattedName} is confused.");
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
