using Fumbbl.Model;
using Fumbbl.Model.Types;
using System.Collections.Generic;

namespace Fumbbl.UI.LogText
{
    public class Block : LogTextGenerator<Ffb.Dto.Reports.Block>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.Block report)
        {
            string attacker = FFB.Instance.Model.GetPlayer(FFB.Instance.Model.ActingPlayer?.PlayerId).FormattedName;
            string defender = FFB.Instance.Model.GetPlayer(report.defenderId).FormattedName;

            ActingPlayer.ActionType action = FFB.Instance.Model.ActingPlayer.CurrentAction;

            string actionString = action == ActingPlayer.ActionType.Blitz ? "blitzes" : "blocks";

            yield return new LogRecord($"{attacker} {actionString} {defender}.");
        }
    }
}
