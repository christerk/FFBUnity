using Fumbbl.Model.Types;
using System.Collections.Generic;

namespace Fumbbl.UI.LogText
{
    public class ArgueTheCallRoll : LogTextGenerator<Ffb.Dto.Reports.ArgueTheCallRoll>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.ArgueTheCallRoll report)
        {
            Player player = FFB.Instance.Model.GetPlayer(report.playerId);
            yield return new LogRecord($"<b>Argue the Call Roll [ {report.roll} ]</b>");
            if (report.successful)
            {
                yield return new LogRecord($"The ref refrains from banning {player.FormattedName} and {player.Gender.Nominative} is sent to the reserve instead.", 1);
            }
            else
            {
                yield return new LogRecord($"The ref bans {player.FormattedName} from the game.", 1);
            }
            if (report.coachBanned)
            {
                yield return new LogRecord($"Coach {player.Team.Coach.FormattedName} is also banned from the game.", 1);
            }
        }
    }
}
