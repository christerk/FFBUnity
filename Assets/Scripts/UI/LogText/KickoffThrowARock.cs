using Fumbbl.Ffb.Dto;
using Fumbbl.Model;
using Fumbbl.Model.Types;
using System.Collections.Generic;
using System.Linq;

namespace Fumbbl.UI.LogText
{
    public class KickoffThrowARock : LogTextGenerator<Ffb.Dto.Reports.KickoffThrowARock>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.KickoffThrowARock report)
        {
            int fanFavouritesHome = 0; // TODO: Count number of fan favourites on team
            int fanFavouritesAway = 0; // TODO: Count number of fan favourites on team

            int totalHome = report.rollHome + FFB.Instance.Model.TeamHome.Fame + fanFavouritesHome;
            int totalAway = report.rollAway + FFB.Instance.Model.TeamAway.Fame + fanFavouritesAway;

            yield return new LogRecord($"<b>Throw a Rock Roll Home Team [ {report.rollHome} ]</b>");
            yield return new LogRecord($"Rolled {report.rollHome} + {FFB.Instance.Model.TeamHome.Fame} FAME + {fanFavouritesHome} Fan Favourites = {totalHome}.", 1);

            yield return new LogRecord($"<b>Throw a Rock Roll Away Team [ {report.rollAway} ]</b>");
            yield return new LogRecord($"Rolled {report.rollAway} + {FFB.Instance.Model.TeamAway.Fame} FAME + {fanFavouritesAway} Fan Favourites = {totalAway}.", 1);

            foreach (var pId in report.playerIdsHit)
            {
                Player p = FFB.Instance.Model.GetPlayer(pId);
                yield return new LogRecord($"{p.FormattedName} is hit by a rock.");
            }
        }
    }
}
