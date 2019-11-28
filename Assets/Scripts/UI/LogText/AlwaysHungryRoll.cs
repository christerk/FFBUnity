using Fumbbl.Model;
using Fumbbl.Model.Types;
using System.Collections.Generic;

namespace Fumbbl.UI.LogText
{
    public class AlwaysHungryRoll : LogTextGenerator<Ffb.Dto.Reports.AlwaysHungryRoll>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.AlwaysHungryRoll report)
        {
            Player thrower = FFB.Instance.Model.GetPlayer(FFB.Instance.Model.ActingPlayer.PlayerId);

            yield return new LogRecord($"Always Hungry Roll [ {report.roll} ]");

            if (report.successful)
            {
                yield return new LogRecord($"{thrower.FormattedName} resists the hunger.", 1);
            }
            else
            {
                yield return new LogRecord($"{thrower.FormattedName} tries to eat {thrower.Gender.Genetive} team-mate.", 1);
            }
        }
    }
}
