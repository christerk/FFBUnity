using Fumbbl;
using Fumbbl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fumbbl.Model
{
    public class PlayerAction
    {
        public string Action { get; set; }
        public int Type { get; set; }
        public string Description { get; set; }
    }

    public static class PlayerActionExtensions
    {
        private static readonly Dictionary<string, PlayerAction> PlayerActions;
        static PlayerActionExtensions()
        {
            PlayerActions = new Dictionary<string, PlayerAction>()
            {
                ["move"] = new PlayerAction() { Action = "move", Description = "starts a Move Action" },
                ["block"] = new PlayerAction() { Action = "block", Description = "starts a Block Action" },
                ["blitz"] = new PlayerAction() { Action = "blitz", Description = null },
                ["blitzMove"] = new PlayerAction() { Action = "blitzMove", Description = "starts a Blitz Action" },
                ["handOver"] = new PlayerAction() { Action = "handOver", Description = null },
                ["handOverMove"] = new PlayerAction() { Action = "handOverMove", Description = "starts a Hand Over Action" },
                ["pass"] = new PlayerAction() { Action = "pass", Description = null },
                ["passMove"] = new PlayerAction() { Action = "passMove", Description = "starts a Pass Action" },
                ["foul"] = new PlayerAction() { Action = "foul", Description = null },
                ["foulMove"] = new PlayerAction() { Action = "foulMove", Description = "starts a Foul Action" },
                ["standUp"] = new PlayerAction() { Action = "standUp", Description = "stands up" },
                ["throwTeamMate"] = new PlayerAction() { Action = "throwTeamMate", Description = null },
                ["throwTeamMateMove"] = new PlayerAction() { Action = "throwTeamMateMove", Description = null },
                ["removeConfusion"] = new PlayerAction() { Action = "removeConfusion", Description = null },
                ["gaze"] = new PlayerAction() { Action = "gaze", Description = null },
                ["multipleBlock"] = new PlayerAction() { Action = "multipleBlock", Description = "starts a Block Action" },
                ["hailMaryPass"] = new PlayerAction() { Action = "hailMaryPass", Description = null },
                ["dumpOff"] = new PlayerAction() { Action = "dumpOff", Description = null },
                ["standUpBlitz"] = new PlayerAction() { Action = "standUpBlitz", Description = "stands up with Blitz" },
                ["throwBomb"] = new PlayerAction() { Action = "throwBomb", Description = "starts a Bomb Action" },
                ["hailMaryBomb"] = new PlayerAction() { Action = "hailMaryBomb", Description = null },
                ["swoop"] = new PlayerAction() { Action = "swoop", Description = null }
            };
        }

        public static PlayerAction AsPlayerAction(this FFBEnumeration ffbEnum)
        {
            return PlayerActions.ContainsKey(ffbEnum.key) ? PlayerActions[ffbEnum.key] : null;
        }
    }
}