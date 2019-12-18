using Fumbbl.Model.Types;
using System.Collections.Generic;

namespace Fumbbl.UI.LogText
{
    public class SkillUse : LogTextGenerator<Ffb.Dto.Reports.SkillUse>
    {
        private string SkillUsageString(string key, string genetive)
        {
            switch (key)
            {
                case "wouldNotHelp":
                    return $"because it would not help";
                case "noTeamMateInRange":
                    return $"because no team-mate is in range";
                case "stopOpponent":
                    return $"to stop {genetive} opponent";
                case "pushBackOpponent":
                    return $"to push {genetive} opponent back";
                case "bringDownOppponent":
                    return $"to bring {genetive} opponent down";
                case "avoidPush":
                    return $"to avoid being pushed";
                case "cancelFend":
                    return $"to cancel {genetive} opponent's Fend skill";
                case "cancelStandFirm":
                    return $"to cancel {genetive} opponent's Stand Firm skill";
                case "stayAwayFromOpponent":
                    return $"to stay away from {genetive} opponent";
                case "catchBall":
                    return $"to catch the ball";
                case "stealBall":
                    return $"to steal the ball";
                case "cancelStripBall":
                    return $"to cancel {genetive} opponent's Strip Ball skill";
                case "halveKickoffScatter":
                    return $"to halve the kickoff scatter";
                case "cancelDodge":
                    return $"to cancel {genetive} opponent's Dodge skill";
                case "avoidFalling":
                    return $"to avoid falling";
                case "cancelTackle":
                    return $"to cancel {genetive} opponent's Tackle skill";
                case "increaseStrengthBy1":
                    return $"to increase {genetive} strength by 1";
                case "cancelDivingCatch":
                    return $"because players from both teams hinder each other";
                default:
                    return $"";
            }
        }

        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.SkillUse report)
        {
            Player player = FFB.Instance.Model.GetPlayer(report.playerId);

            string used = report.used ? "used" : "didnt use";
            yield return new LogRecord($"{player.FormattedName} {used} {report.skill} {SkillUsageString(report.skillUse, player.Gender.Genetive)}");

        }
    }
}
