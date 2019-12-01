﻿using Fumbbl.Model.Types;
using System.Collections.Generic;

namespace Fumbbl.UI.LogText
{
    public class Foul : LogTextGenerator<Ffb.Dto.Reports.Foul>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.Foul report)
        {
            Player attacker = FFB.Instance.Model.GetPlayer(FFB.Instance.Model.ActingPlayer.PlayerId);
            Player defender = FFB.Instance.Model.GetPlayer(report.defenderId);
            yield return new LogRecord($"{attacker.FormattedName} fouls {defender.FormattedName}:");
        }
    }
}
