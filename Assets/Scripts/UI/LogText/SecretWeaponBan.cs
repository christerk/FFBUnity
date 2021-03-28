using System;
using System.Collections.Generic;
using System.Linq;
using Fumbbl.Model;

namespace Fumbbl.UI.LogText
{
    public class SecretWeaponBan : LogTextGenerator<Ffb.Dto.Reports.SecretWeaponBan>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.SecretWeaponBan report)
        {
            foreach (LogRecord logrecord in ConvertHomeOrAway(report, true))
            {
                yield return logrecord;
            }
            foreach (LogRecord logrecord in ConvertHomeOrAway(report, false))
            {
                yield return logrecord;
            }
        }

        private IEnumerable<LogRecord> ConvertHomeOrAway(Ffb.Dto.Reports.SecretWeaponBan report, bool home)
        {
            for (int i = 0; i < report.banArray.Length; i++)
            {
                var player = FFB.Instance.Model.GetPlayer(report.playerIds[i]);
                if (player.IsHome != home) continue;
                if (report.banArray[i])
                {
                    yield return new LogRecord($"The ref bans {player.FormattedName} for using a Secret Weapon.");
                }
                else
                {
                    yield return new LogRecord($"The ref overlooks {player.FormattedName} using a Secret Weapon.");
                }
                if (0 < report.rolls[i])
                {
                    int? skillvalue = null;
                    foreach (Model.Types.Skill skill in player.Skills)
                    {
                        if (skill.Name == Model.Types.Skill.SecretWeapon.Name)
                        {
                            skillvalue = skill.Value;
                            break;
                        }
                    }
                    if (skillvalue != null)
                    {
                        yield return new LogRecord($"Penalty roll was {report.rolls[i]}, banned on a {skillvalue}+", 1);
                    }
                }
            }
        }
    }
}
