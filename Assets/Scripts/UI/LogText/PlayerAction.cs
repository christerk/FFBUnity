using Fumbbl.Model;
using System.Collections.Generic;

namespace Fumbbl.UI.LogText
{
    public class PlayerAction : LogTextGenerator<Ffb.Dto.Reports.PlayerAction>
    {
        private static readonly Dictionary<string, string> ActionStrings = new Dictionary<string, string>()
        {
            ["move"] = "starts a Move Action",
            ["block"] = "starts a Block Action",
            ["blitzMove"] = "starts a Blitz Action",
            ["handOverMove"] = "starts a Hand Over Action",
            ["passMove"] = "starts a Pass Action",
            ["foulMove"] = "starts a Foul Action",
            ["standUp"] = "stands up",
            ["multipleBlock"] = "starts a Block Action",
            ["standUpBlitz"] = "stands up with Blitz",
            ["throwBomb"] = "starts a Bomb Action",
        };

        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.PlayerAction report)
        {
            var action = report.playerAction.AsPlayerAction();
            if (action != null && action.Description != null)
            {
                yield return new LogRecord($"{ FFB.Instance.Model.GetPlayer(report.actingPlayerId).FormattedName } { action.Description }.");

            }
        }
    }
}
