using Fumbbl.Model;
using Fumbbl.Model.Types;
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

            yield return new LogRecord($"<b>Dodge Roll [ { report.roll } ]</b>");

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
                neededRoll = $"Succeeded on a roll of { report.minimumRoll }+";
            }
            else
            {
                yield return new LogRecord($"{ player.FormattedName } trips while dodging.", 1);
                neededRoll = $"Roll a { report.minimumRoll }+ to succeed";
            }

            if (neededRoll != "")
            {
                {
                    if (rollModifiers.Contains(DodgeModifier.BreakTackle))
                    {
                        neededRoll += $" using Break Tackle (ST { System.Math.Min(6, player.Strength) }";
                    }
                    else
                    {
                        neededRoll += $" (AG { System.Math.Min(6, player.Agility) }";
                    }
                }
                neededRoll += " + 1 Dodge";
                // neededRoll += concatenated formatted rollmodifiers
                neededRoll += " + Roll > 6).";
                yield return new LogRecord(neededRoll , 1);
            }
        }
    }
}