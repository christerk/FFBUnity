using Fumbbl.Model;
using Fumbbl.Model.RollModifier;
using Fumbbl.Model.Types;
using System.Collections.Generic;
using System.Linq;

namespace Fumbbl.UI.LogText
{
    public class GoForItRoll : LogTextGenerator<Ffb.Dto.Reports.GoForItRoll>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.GoForItRoll report)
        {
            Player player = FFB.Instance.Model.GetPlayer(FFB.Instance.Model.ActingPlayer.PlayerId);

            yield return new LogRecord($"<b>Go For It Roll [ {report.roll} ]");

            IEnumerable<GoForItModifier> rollModifiers = report.rollModifiers?.Select(r => r.As<GoForItModifier>());

            string modifiers = rollModifiers != null ? string.Join("", rollModifiers.Select(m => m.ModifierString)) : "";
            if (report.successful)
            {
                yield return new LogRecord($"{player.FormattedName} goes for it!", 1);

                if (report.reRolled)
                {
                    yield return new LogRecord($"Succeeded on a roll of {report.minimumRoll}+ (Roll{modifiers} > {report.minimumRoll-1}).");
                }
            }
            else
            {
                yield return new LogRecord($"{player.FormattedName} trips while going for it. (Roll{modifiers} > {report.minimumRoll-1}).", 1);

            }
        }
    }
}
