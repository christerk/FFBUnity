using Fumbbl.Model;
using Fumbbl.Model.RollModifier;
using Fumbbl.Model.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fumbbl.UI.LogText
{
    public class InterceptionRoll : LogTextGenerator<Ffb.Dto.Reports.InterceptionRoll>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.InterceptionRoll report)
        {
            Player player = FFB.Instance.Model.GetPlayer(report.playerId);
            string neededRoll = "";

            IEnumerable<InterceptionModifier> rollModifiers = report.rollModifiers?.Select(r => r.As<InterceptionModifier>());

            if (!report.reRolled)
            {
                if (report.bomb)
                {
                    yield return new LogRecord($"<b>{player.FormattedName} tries to intercept the bomb:</b>");
                }
                else
                {
                    yield return new LogRecord($"<b>{player.FormattedName} tries to intercept the ball:</b>");
                }
                if (rollModifiers.Contains(InterceptionModifier.NervesOfSteel))
                {
                    yield return new LogRecord($"{player.FormattedName} is using Nerves of Steel to intercept the ball.");
                }
            }

            yield return new LogRecord($"<b>Interception Roll [ {report.roll} ]</b>", 1);

            if (report.successful)
            {
                if (report.bomb)
                {
                    yield return new LogRecord($"{player.FormattedName} intercepts the bomb.", 2);
                }
                else
                {
                    yield return new LogRecord($"{player.FormattedName} intercepts the ball.", 2);
                }

                if (!report.reRolled)
                {
                    neededRoll = $"Succeeded on a roll of {report.minimumRoll}+";
                }
            }
            else
            {
                if (report.bomb)
                {
                    yield return new LogRecord($"{player.FormattedName} fails to intercept the bomb.", 2);
                }
                else
                {
                    yield return new LogRecord($"{player.FormattedName} fails to intercept the ball.", 2);
                }

                if (!report.reRolled)
                {
                    neededRoll = $"Roll a {report.minimumRoll}+ to succeed";
                }
            }

            if (!string.IsNullOrEmpty(neededRoll))
            {
                neededRoll += $" (AG {Math.Min(6, player.Agility)}";

                neededRoll += " - 2 Interception";

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