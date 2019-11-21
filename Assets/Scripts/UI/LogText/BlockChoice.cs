using Assets.Scripts.Model;
using Fumbbl.Ffb.Dto;
using Fumbbl.Model;

namespace Fumbbl.UI.LogText
{
    public class BlockChoice : LogTextGenerator
    {
        public BlockChoice() : base(typeof(Ffb.Dto.Reports.BlockChoice)) { }

        public override string Convert(Report report)
        {
            Ffb.Dto.Reports.BlockChoice blockChoice = (Ffb.Dto.Reports.BlockChoice)report;

            BlockDieType blockResult = Util.GetBlockDie(blockChoice.blockResult);
            string result = $"Block Result [ { blockResult.GetName() } ]";

            Player attacker = FFB.Instance.Model.GetPlayer(FFB.Instance.Model.ActingPlayer.PlayerId);
            Player defender = FFB.Instance.Model.GetPlayer(blockChoice.defenderId);

            switch (blockResult)
            {
                case BlockDieType.BOTH_DOWN:
                    if (attacker.HasSkill(SkillType.Block))
                    {
                        result += $"\n{ attacker.FormattedName } has been saved by { attacker.Gender.Genetive } Block skill.";
                    }
                    if (defender.HasSkill(SkillType.Block))
                    {
                        result += $"\n{ defender.FormattedName } has been saved by { defender.Gender.Genetive } Block skill.";
                    }
                    break;
                case BlockDieType.POW_PUSHBACK:
                    if (defender.HasSkill(SkillType.Dodge) && attacker.HasSkill(SkillType.Tackle))
                    {
                        result += $"\n{ attacker.FormattedName } uses Tackle to bring opponent down.";
                    }
                    break;
            }

            return result;
        }
    }
}
