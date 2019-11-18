using Fumbbl.Dto;
using System.Collections.Generic;

namespace Fumbbl.UI.LogText
{
    [ReportType(typeof(Dto.Reports.PlayerAction))]
    public class PlayerAction : ILogTextGenerator
    {
        private static Dictionary<string, string> ActionStrings = new Dictionary<string, string>()
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

        public string Convert(IReport report)
        {
            Dto.Reports.PlayerAction action = (Dto.Reports.PlayerAction)report;

            if (ActionStrings.ContainsKey(action.playerAction))
            {
                return $"{ FFB.Instance.GetPlayerName(action.actingPlayerId) } { ActionStrings[action.playerAction] }.";
            }
            return null;

        }
    }
}
