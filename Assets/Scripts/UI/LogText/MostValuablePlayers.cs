using Fumbbl.Model.Types;
using System.Collections.Generic;

namespace Fumbbl.UI.LogText
{
    public class MostValuablePlayers : LogTextGenerator<Ffb.Dto.Reports.MostValuablePlayers>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.MostValuablePlayers report)
        {
            yield return new LogRecord($"<b>Most Valuable Player</b>");
            foreach(string playerId in report.playerIdsHome)
            {
                yield return new LogRecord(GenerateMvpText(playerId), 1);
            }
            foreach(string playerId in report.playerIdsAway)
            {
                yield return new LogRecord(GenerateMvpText(playerId), 1);
            }
        }

        private string GenerateMvpText(string playerId)
        {
            Player player = FFB.Instance.Model.GetPlayer(playerId);
            return $"The jury voted {player.FormattedName} the most valuable member of the team";
        }

    }
}
