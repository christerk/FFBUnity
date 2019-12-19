using Fumbbl.Model.Types;
using System.Collections.Generic;

namespace Fumbbl.UI.LogText
{
    public class Referee : LogTextGenerator<Ffb.Dto.Reports.Referee>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.Referee report)
        {
           if(report.foulingPlayerBanned)
           {
                yield return new LogRecord($"The referee spots the player and bans them from the game", 1);
           }
           else
           {
                yield return new LogRecord($"The referee didn't spot the foul.", 1);
           }
        }
    }
}
