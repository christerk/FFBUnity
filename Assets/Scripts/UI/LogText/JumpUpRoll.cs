using Fumbbl.Model;
using Fumbbl.Model.RollModifier;
using Fumbbl.Model.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fumbbl.UI.LogText
{
    public class JumpUpRoll : LogTextGenerator<Ffb.Dto.Reports.JumpUpRoll>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.JumpUpRoll report)
        {
            Player player = FFB.Instance.Model.GetPlayer(report.playerId);
            string neededRoll = "";

            yield return new LogRecord($"<b>Jump Up Roll [ {report.roll} ]</b>");

            if (report.successful)
            {
                yield return new LogRecord($"{player.FormattedName} jumps up to block {player.Gender.Genetive} opponent.", 1);
                if (!report.reRolled)
                {
                    neededRoll = $"Succeeded on a roll of {report.minimumRoll}+";
                }
            }
            else
            {
                yield return new LogRecord($"{player.FormattedName} doesn't get to {player.Gender.Genetive} feet.", 1);
                if (!report.reRolled)
                {
                    neededRoll = $"Roll a {report.minimumRoll}+ to succeed";
                }
            }

            if (!string.IsNullOrEmpty(neededRoll))
            {
                neededRoll += $" (AG {Math.Min(6, player.Agility)} + 2 Jump Up + Roll > 6).";
                yield return new LogRecord(neededRoll, 1);
            }
        }
    }
}
