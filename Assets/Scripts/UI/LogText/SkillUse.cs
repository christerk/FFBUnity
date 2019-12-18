using Fumbbl.Model.Types;
using System.Collections.Generic;
using UnityEngine;

namespace Fumbbl.UI.LogText
{
    public class SkillUse : LogTextGenerator<Ffb.Dto.Reports.SkillUse>
    {
        private string SkillUsageString(string key, Player player)
        {
            switch (key)
            {
                case "wouldNotHelp":
                    return $"because it would not help";
                case "noTeamMateInRange":
                    return $"because no team-mate is in range";
                case "stopOpponent":
                    return $"to stop {player.Gender.Genetive} opponent";
                case "pushBackOpponent":
                    return $"to push {player.Gender.Genetive} opponent back";
                case "bringDownOppponent":
                    return $"to bring {player.Gender.Genetive} opponent down";
                case "avoidPush":
                    return $"to avoid being pushed";
                case "cancelFend":
                    return $"to cancel {player.Gender.Genetive} opponent's Fend skill";
                case "cancelStandFirm":
                    return $"to cancel {player.Gender.Genetive} opponent's Stand Firm skill";
                case "stayAwayFromOpponent":
                    return $"to stay away from {player.Gender.Genetive} opponent";
                case "catchBall":
                    return $"to catch the ball";
                case "stealBall":
                    return $"to steal the ball";
                case "cancelStripBall":
                    return $"to cancel {player.Gender.Genetive} opponent's Strip Ball skill";
                case "halveKickoffScatter":
                    return $"to halve the kickoff scatter";
                case "cancelDodge":
                    return $"to cancel {player.Gender.Genetive} opponent's Dodge skill";
                case "avoidFalling":
                    return $"to avoid falling";
                case "cancelTackle":
                    return $"to cancel {player.Gender.Genetive} opponent's Tackle skill";
                case "increaseStrengthBy1":
                    return $"to increase {player.Gender.Genetive} strength by 1";
                case "cancelDivingCatch":
                    return $"because players from both teams hinder each other";
                default:
                    return $"Unhandled skill roll string {key}";
            }
        }

        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.SkillUse report)
        {
            Player player = FFB.Instance.Model.GetPlayer(report.playerId);

            string used = report.used ? "used" : "didnt use";
            Debug.Log("Skillusage: " + report);
            yield return new LogRecord($"{player.FormattedName} {used} {report.skill} {SkillUsageString(report.skillUse, player)}");
        }
    }
}
