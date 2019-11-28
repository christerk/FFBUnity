using Fumbbl.Model;
using Fumbbl.Model.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fumbbl.UI.LogText
{
    public class DodgeRoll : LogTextGenerator<Ffb.Dto.Reports.DodgeRoll>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.DodgeRoll report)
        {
            Player player = FFB.Instance.Model.GetPlayer(report.playerId);
            string neededRoll = "";

            IEnumerable<DodgeModifier> rollModifiers = report.rollModifiers.Select(r => r.AsDodgeModifier());

            yield return new LogRecord($"<b>Dodge Roll [ { report.roll } ]</b>");

            if (!report.reRolled)
            {
                if (rollModifiers.Contains(DodgeModifier.Stunty))
                {
                    yield return new LogRecord($"{ player.FormattedName } is Stunty and ignores tacklezones.", 1);
                }
                if (rollModifiers.Contains(DodgeModifier.BreakTackle))
                {
                    yield return new LogRecord($"{ player.FormattedName } uses Break Tackle to break free.", 1);
                }
            }

            if (report.successful)
            {
                yield return new LogRecord($"{ player.FormattedName } dodges successfully.", 1);
                neededRoll = $"Succeeded on a roll of { report.minimumRoll }+";
            }
            else
            {
                yield return new LogRecord($"{ player.FormattedName } trips while dodging.", 1);
                neededRoll = $"Roll a { report.minimumRoll }+ to succeed";
            }

            if (neededRoll != "")
            {
//                if (report.rollModifiers.Contains("Break Tackle"))
//                {
//                    neededRoll += $" using Break Tackle (ST { Min(6, player.ST) }"
//                }
//                else
//                {
//                    neededRoll += $" (AG { Min(6, player.AG) }"
//                }
                neededRoll += " + 1 Dodge";
                // neededRoll += rollmodifiers ...
                neededRoll += " + Roll > 6).";
                yield return new LogRecord(neededRoll , 1);
            }
        }
    }
}