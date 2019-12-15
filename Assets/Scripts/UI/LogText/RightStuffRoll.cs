using Fumbbl.Model;
using Fumbbl.Model.Types;
using Fumbbl.Model.RollModifier;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fumbbl.UI.LogText
{
    public class RightStuffRoll : LogTextGenerator<Ffb.Dto.Reports.RightStuffRoll>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.RightStuffRoll report)
        {
            Player player = FFB.Instance.Model.GetPlayer(report.playerId);
            string neededRoll = "";

            IEnumerable<RightStuffModifier> rollModifiers = report.rollModifiers?.Select(r => r.As<RightStuffModifier>());

            yield return new LogRecord($"<b>Right Stuff Roll [ {report.roll} ]</b>");

            if (report.successful)
            {
                yield return new LogRecord($"{player.FormattedName} lands on {player.Gender.Genetive} feet.", 1);
                if (!report.reRolled)
                {
                    neededRoll = $"Succeeded on a roll of {report.minimumRoll}+";
                }
            }
            else
            {
                yield return new LogRecord($"{player.FormattedName} crashes to the ground.", 1);
                if (!report.reRolled)
                {
                    neededRoll = $"Roll a {report.minimumRoll}+ to succeed";
                }
            }

            if (!string.IsNullOrEmpty(neededRoll))
            {
                neededRoll += $" (AG {Math.Min(6, player.Agility)}";
                if (rollModifiers != null)
                {
                    neededRoll += string.Join("", rollModifiers.Select(m => m.ModifierString));
                }

                neededRoll += " + Roll > 6).";
                yield return new LogRecord(neededRoll, 2);
            }
        }
    }
}
