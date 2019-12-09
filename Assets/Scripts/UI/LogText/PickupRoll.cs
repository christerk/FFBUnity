using Fumbbl.Model;
using Fumbbl.Model.RollModifier;
using Fumbbl.Model.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fumbbl.UI.LogText
{
  public class PickupRoll : LogTextGenerator<Ffb.Dto.Reports.PickupRoll>
  {
    public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.PickupRoll report)
    {
      Player player = FFB.Instance.Model.GetPlayer(report.playerId);
      string neededRoll = "";

      yield return new LogRecord($"{player.FormattedName} tries to pick up the ball.", 1);
      
      IEnumerable<PickupModifier> rollModifiers = report.rollModifiers?.Select(r => r.As<PickupModifier>());

      if (rollModifiers.Contains(PickupModifier.BigHand))
      {
        yield return new LogRecord($"{player.FormattedName} is using Big Hand to ignore any tacklezones on the ball.", 1);
      }

      yield return new LogRecord($"<b>Pickup Roll [ {report.roll} ]</b>");

      if (report.successful)
      {
        yield return new LogRecord($"{player.FormattedName} picks up the ball.", 1);
        if (!report.reRolled)
        {
          neededRoll = $"Succeeded on a roll of {report.minimumRoll}+ ";
        }
      }
      else
      {
        yield return new LogRecord($"{player.FormattedName} drops the ball", 1);
        if (!report.reRolled)
        {
          neededRoll = $"Roll a {report.minimumRoll}+ to succeed.";
        }
      }

      if (!string.IsNullOrEmpty(neededRoll))
      {
        neededRoll += $" (AG {Math.Min(6, player.Agility)} + 1 Pickup";

        if (rollModifiers != null)
        {
          // Only show modifiers strings if the player doesn't have Big Hand 
          if (!rollModifiers.Contains(PickupModifier.BigHand))
          {
            neededRoll += string.Join("", rollModifiers.Select(m => m.ModifierString));
          }
        }

        neededRoll += " + Roll > 6).";

        yield return new LogRecord(neededRoll, 1);
      }
    }
  }
}