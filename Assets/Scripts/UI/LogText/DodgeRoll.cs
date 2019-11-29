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

            IEnumerable<DodgeModifier> rollModifiers = report.rollModifiers?.Select(r => r.AsDodgeModifier());

            if (report.roll > 0)
            {
                yield return new LogRecord($"<b>Dodge Roll [ { report.roll } ]</b>");
            }
            else
            {
                yield return new LogRecord($"<b>New Dodge Result</b>");
            }

            if (!report.reRolled && rollModifiers != null)
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
                if (!report.reRolled)
                {
                    neededRoll = $"Succeeded on a roll of { report.minimumRoll }+";
                }
            }
            else
            {
                yield return new LogRecord($"{ player.FormattedName } trips while dodging.", 1);
                if (!report.reRolled)
                {
                    neededRoll = $"Roll a { report.minimumRoll }+ to succeed";
                }
            }

            if (!string.IsNullOrEmpty(neededRoll))
            {
                if (rollModifiers != null && rollModifiers.Contains(DodgeModifier.BreakTackle))
                {
                    neededRoll += $" using Break Tackle (ST { Math.Min(6, player.Strength) }";
                }
                else
                {
                    neededRoll += $" (AG { System.Math.Min(6, player.Agility) }";
                }

                neededRoll += " + 1 Dodge";
                if (rollModifiers != null)
                {
                    neededRoll += string.Join("", rollModifiers.Select(m => m.GetModifierString()));
                }

                neededRoll += " + Roll > 6).";
                yield return new LogRecord(neededRoll , 1);
            }
        }
    }
}