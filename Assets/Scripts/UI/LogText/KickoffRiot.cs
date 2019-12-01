using Fumbbl.Ffb.Dto;
using Fumbbl.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fumbbl.UI.LogText
{
    public class KickoffRiot : LogTextGenerator<Ffb.Dto.Reports.KickoffRiot>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.KickoffRiot report)
        {
            if (report.roll > 0)
            {
                yield return new LogRecord($"<b>Riot Roll [ {report.roll} ]</b>");
            }
            else
            {
                int turn = FFB.Instance.Model.HomePlaying ? FFB.Instance.Model.TurnHome : FFB.Instance.Model.TurnAway;
                yield return new LogRecord($"<b>Riot in Turn {turn}</b>");
            }

            string steps = report.turnModifier == 1 ? "step" : "steps";
            if (report.turnModifier < 0)
            {
                yield return new LogRecord($"The referee adjusts the clock back after the riot is over.", 1);
                yield return new LogRecord($"Turn counter is moved {Math.Abs(report.turnModifier)} {steps} backward.", 1);
            }
            else
            {
                yield return new LogRecord($"The referee does not stop the clock during the riot.", 1);
                yield return new LogRecord($"Turn counter is moved {Math.Abs(report.turnModifier)} {steps} forward.", 1);
            }
        }
    }
}
