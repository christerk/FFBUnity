using Fumbbl.Model.Types;
using System.Collections.Generic;

namespace Fumbbl.UI.LogText
{
    public class PilingOn : LogTextGenerator<Ffb.Dto.Reports.PilingOn>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.PilingOn report)
        {
            Player player = FFB.Instance.Model.GetPlayer(report.playerId);
            string used = report.used ? "uses" : "does not use"; 
            string armourOrInjury = report.used? report.reRollInjury ? " to re-roll Injury" : " to re-roll Armour" : "";
            yield return new LogRecord($" {player.FormattedName} {used} Piling On{armourOrInjury}.", 1);
        }
    }
}
