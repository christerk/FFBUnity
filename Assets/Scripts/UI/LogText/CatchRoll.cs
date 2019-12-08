using Fumbbl.Model;
using Fumbbl.Model.RollModifier;
using Fumbbl.Model.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fumbbl.UI.LogText
{
    public class CatchRoll : LogTextGenerator<Ffb.Dto.Reports.CatchRoll>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.CatchRoll report)
        {
            Player player = FFB.Instance.Model.GetPlayer(report.playerId);
            string neededRoll = "";

            IEnumerable<CatchModifier> rollModifiers = report.rollModifiers?.Select(r => r.As<CatchModifier>());

            if (!report.reRolled)
            {
                if (report.bomb)
                {
                    yield return new LogRecord($"<b>{player.FormattedName} tries to catch the bomb:</b>");
                }
                else
                {
                    yield return new LogRecord($"<b>{player.FormattedName} tries to catch the ball:</b>");
                }
                if (rollModifiers != null && rollModifiers.Contains(CatchModifier.NervesOfSteel))
                {
                    yield return new LogRecord($"{player.FormattedName} is using Nerves of Steel to catch the ball.");
                }
            }

            yield return new LogRecord($"<b>Catch Roll [ {report.roll} ]</b>", 1);

            if (report.successful)
            {
                if (report.bomb)
                {
                    yield return new LogRecord($"{player.FormattedName} catches the bomb.", 2);
                }
                else
                {
                    yield return new LogRecord($"{player.FormattedName} catches the ball.", 2);
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
                    yield return new LogRecord($"{player.FormattedName} drops the bomb.", 2);
                }
                else
                {
                    yield return new LogRecord($"{player.FormattedName} drops the ball.", 2);
                }

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