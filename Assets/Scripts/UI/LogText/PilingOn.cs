using Fumbbl.Model.Types;
using System.Collections.Generic;

namespace Fumbbl.UI.LogText
{
    public class PilingOn : LogTextGenerator<Ffb.Dto.Reports.PilingOn>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.PilingOn report)
        {
            Player player = FFB.Instance.Model.GetPlayer(report.playerId);
            if(!report.used)
            {
                yield return new LogRecord($"{player.FormattedName} does not use Piling On.", 1);
            }
            else
            {
                string armourOrInjury = report.reRollInjury ? "Injury" : "Armour";
                yield return new LogRecord($"{player.FormattedName} uses Piling On to re-roll {armourOrInjury}.", 1);
            }
        }
    }
}
