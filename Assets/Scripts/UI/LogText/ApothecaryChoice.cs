using Fumbbl.Model.Types;
using System.Collections.Generic;

namespace Fumbbl.UI.LogText
{
    public class ApothecaryChoice : LogTextGenerator<Ffb.Dto.Reports.ApothecaryChoice>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.ApothecaryChoice report)
        {
            Player player = FFB.Instance.Model.GetPlayer(FFB.Instance.Model.ActingPlayer.PlayerId);
            Coach coach = player?.Team?.Coach;

            if (coach != null && player != null)
            {
                if (PlayerState.Get(report.playerState).IsReserve)
                {
                    yield return new LogRecord($"The apothecary patches {player.FormattedName} up so {player.Gender.Nominative} is able to play again.");
                }
                else
                {
                    PlayerState oldState = player.PlayerState;
                    SeriousInjury oldInjury = player.SeriousInjury;

                    if (PlayerState.Get(report.playerState) != oldState || report.seriousInjury.AsSeriousInjury() != oldInjury)
                    {
                        yield return new LogRecord($"Coach {coach.FormattedName} chooses the new injury result.");
                    }
                    else
                    {
                        yield return new LogRecord($"Coach {coach.FormattedName} keeps the old injury result.");
                    }
                }
            }
        }
    }
}
