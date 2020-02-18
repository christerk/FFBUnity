using Fumbbl.Model.Types;
using System.Collections.Generic;

namespace Fumbbl.UI.LogText
{
    public class WizardUse : LogTextGenerator<Ffb.Dto.Reports.WizardUse>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.WizardUse report)
        {
            Team team = FFB.Instance.Model.GetTeam(report.teamId);
            yield return new LogRecord($" The team wizard for: {team.FormattedName} casts a {report.specialEffect} spell.");
        }
    }
}
