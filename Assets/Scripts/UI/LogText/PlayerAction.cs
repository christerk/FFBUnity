using Fumbbl.Model;
using System.Collections.Generic;

namespace Fumbbl.UI.LogText
{
    public class PlayerAction : LogTextGenerator<Ffb.Dto.Reports.PlayerAction>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.PlayerAction report)
        {
            var action = report.playerAction.AsPlayerAction();
            if (action != null && action.Description != null)
            {
                yield return new LogRecord($"<b>{ FFB.Instance.Model.GetPlayer(report.actingPlayerId).FormattedName } { action.Description }.</b>");

            }
        }
    }
}
