using Assets.Scripts.Model;
using Fumbbl.Ffb.Dto;
using Fumbbl.Model;
using System.Collections.Generic;

namespace Fumbbl.UI.LogText
{
    public class BlockChoice : LogTextGenerator<Ffb.Dto.Reports.BlockChoice>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.BlockChoice report)
        {
            BlockDieType blockResult = Util.GetBlockDie(report.blockResult);
            yield return new LogRecord($"Block Result [ { blockResult.GetName() } ]");

            Player attacker = FFB.Instance.Model.GetPlayer(FFB.Instance.Model.ActingPlayer.PlayerId);
            Player defender = FFB.Instance.Model.GetPlayer(report.defenderId);

            switch (blockResult)
            {
                case BlockDieType.BOTH_DOWN:
                    if (attacker.HasSkill(SkillType.Block))
                    {
                        yield return new LogRecord($"{ attacker.FormattedName } has been saved by { attacker.Gender.Genetive } Block skill.");
                    }
                    if (defender.HasSkill(SkillType.Block))
                    {
                        yield return new LogRecord($"\n{ defender.FormattedName } has been saved by { defender.Gender.Genetive } Block skill.");
                    }
                    break;
                case BlockDieType.POW_PUSHBACK:
                    if (defender.HasSkill(SkillType.Dodge) && attacker.HasSkill(SkillType.Tackle))
                    {
                        yield return new LogRecord($"\n{ attacker.FormattedName } uses Tackle to bring opponent down.");
                    }
                    break;
            }
        }
    }
}
