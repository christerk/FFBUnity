using Fumbbl.Model;
using Fumbbl.Model.Types;
using System.Collections.Generic;

namespace Fumbbl.UI.LogText
{
    public class ReRoll : LogTextGenerator<Ffb.Dto.Reports.ReRoll>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.ReRoll report)
        {
            Player player = FFB.Instance.Model.GetPlayer(report.playerId);

            if (report.reRollSource == "Loner")
            {
                yield return new LogRecord($"<b>Loner Roll [ {report.roll} ]</b>", 1);

                string success = report.successful ? "may use" : "wastes";
                yield return new LogRecord($"{player.FormattedName} {success} a Team Re-Roll.", 2);
            }
            else if (report.reRollSource == "Pro")
            {
                yield return new LogRecord($"<b>Pro Roll [ {report.roll} ]</b>", 1);

                if (report.successful)
                {
                    yield return new LogRecord($"{player.FormattedName}'s Pro skill allows {player.Gender.Dative} to re-roll the action.", 2);
                }
                else
                {
                    yield return new LogRecord($"{player.FormattedName}'s Pro skill does not help {player.Gender.Dative}.", 2);
                }
            }
            else
            {
                yield return new LogRecord($"Re-Roll using {report.reRollSource.ToUpper()}.", 1);
            }
        }
    }
}
