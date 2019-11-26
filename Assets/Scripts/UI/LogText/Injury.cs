using Fumbbl.Model;
using System.Collections.Generic;

namespace Fumbbl.UI.LogText
{
    public class Injury : LogTextGenerator<Ffb.Dto.Reports.Injury>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.Injury report)
        {
            Player attacker = FFB.Instance.Model.GetPlayer(report.attackerId);
            Player defender = FFB.Instance.Model.GetPlayer(report.defenderId);

            switch (report.injuryType)
            {
                case "crowdpush":
                    yield return new LogRecord($"{defender.FormattedName} is pushed into the crowd.", 1);
                    break;
                case "stab":
                    if (attacker != null)
                    {
                        yield return new LogRecord($"{attacker.FormattedName} stabs {defender.FormattedName}:", 1);
                    }
                    else
                    {
                        yield return new LogRecord($"{defender.FormattedName} is stabbed:", 1);
                    }
                    break;
                case "bitten":
                    yield return new LogRecord($"{attacker.FormattedName} bites {defender.FormattedName}:", 1);
                    break;
                case "ballAndChain":
                    yield return new LogRecord($"{defender.FormattedName} is knocked out by {defender.Gender.Genetive} own Ball & Chain.", 1);
                    break;
            }

            if (report.armorRoll?.Length > 0)
            {
                yield return new LogRecord($"Armour Roll [ {report.armorRoll[0]} ][ {report.armorRoll[1]} ]");

                //
                // TODO: Incomplete
                //
            }

            if (report.armorBroken && report.injuryRoll?.Length > 0)
            {
                yield return new LogRecord($"Injury Roll [ {report.injuryRoll[0]} ][ {report.injuryRoll[1]} ]");

                //
                // TODO: Incomplete
                //
            }

            yield return new LogRecord($"* * * Incomplete Report Handler (injury) * * *");

        }
    }
}
