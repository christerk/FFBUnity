using Fumbbl.Model;
using System.Collections.Generic;

namespace Fumbbl.UI.LogText
{
    public class ApothecaryChoice : LogTextGenerator<Ffb.Dto.Reports.ApothecaryChoice>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.ApothecaryChoice report)
        {
            Model.Types.Player player = FFB.Instance.Model.GetPlayer(FFB.Instance.Model.ActingPlayer.PlayerId);
            Model.Types.Coach coach = player?.Team?.Coach;

            if (coach != null && player != null)
            {
                if (Model.Types.PlayerState.Get(report.playerState).IsReserve)
                {
                    yield return new LogRecord($"The apothecary patches {player.FormattedName} up so {player.Gender.Nominative} is able to play again.");
                }
                else
                {
                    Model.Types.PlayerState oldState = player.PlayerState;
                    Model.Types.SeriousInjury oldInjury = player.SeriousInjury;
                    var newInjury = report.seriousInjury.As<Model.Types.SeriousInjury>();

                    if (Model.Types.PlayerState.Get(report.playerState) != oldState || newInjury != oldInjury)
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
