using Fumbbl.Ffb.Dto;
using System.Collections.Generic;

namespace Fumbbl.UI.LogText
{
    public class PlayerAction : LogTextGenerator
    {
        public PlayerAction() : base(typeof(Ffb.Dto.Reports.PlayerAction)) { }

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

        public override string Convert(Report report)
        {
            Ffb.Dto.Reports.PlayerAction action = (Ffb.Dto.Reports.PlayerAction)report;

            if (ActionStrings.ContainsKey(action.playerAction))
            {
                return $"{ FFB.Instance.Model.GetPlayer(action.actingPlayerId).FormattedName } { ActionStrings[action.playerAction] }.";
            }
            return null;

        }
    }
}
