using Fumbbl.Model;
using Fumbbl.Model.Types;
using Fumbbl.Model.RollModifier;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fumbbl.UI.LogText
{
    public class Pushback : LogTextGenerator<Ffb.Dto.Reports.Pushback>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.Pushback report)
        {
            Player attacker = FFB.Instance.Model.GetPlayer(FFB.Instance.Model.ActingPlayer.PlayerId);
            Player defender = FFB.Instance.Model.GetPlayer(report.defenderId);
            switch (report.pushbackMode)
            {
                case "regular":
                    break;
                case "grab":
                    yield return new LogRecord($"{attacker.FormattedName} uses Grab to place {attacker.Gender.Genetive} opponent.", 1);
                    break;
                case "sideStep":
                    yield return new LogRecord($"{defender.FormattedName} uses Side Step to avoid being pushed.", 1);
                    break;
            }
        }
    }
}