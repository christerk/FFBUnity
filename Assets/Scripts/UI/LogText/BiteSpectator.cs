using Fumbbl.Ffb.Dto;
using Fumbbl.Model;
using System.Collections.Generic;
using System.Linq;

namespace Fumbbl.UI.LogText
{
    public class BiteSpectator : LogTextGenerator<Ffb.Dto.Reports.BiteSpectator>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.BiteSpectator report)
        {
            Player player = FFB.Instance.Model.GetPlayer(report.playerId);
            if (player != null)
            {
                yield return new LogRecord($"{player.FormattedName} heads off to the spectator ranks to bite some beautiful maiden.");
            }
        }
    }
}
