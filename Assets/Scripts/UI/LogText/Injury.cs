using Fumbbl.Model;
using Fumbbl.Model.RollModifier;
using Fumbbl.Model.Types;
using System.Collections.Generic;
using System.Linq;

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
                yield return new LogRecord($"<b>Armour Roll [ {report.armorRoll[0]} ][ {report.armorRoll[1]} ]</b>");
                var totalArmourRoll = report.armorRoll[0] + report.armorRoll[1];
                yield return new LogRecord($"Rolled Total of {totalArmourRoll} ");

                var modifiers = report.armorModifiers.Select(m => m.As<ArmorModifier>());
                if (modifiers.Count() > 0)
                {
                    var modifierString = string.Join("", modifiers.Select(m => m.ModifierString));
                    var totalArmourRollPlusModifiers = totalArmourRoll + modifiers.Sum(m => m.Modifier);
                    yield return new LogRecord($"{modifierString} = {totalArmourRollPlusModifiers}");
                } 

                bool usesClaws = modifiers.Contains(ArmorModifier.Claws);
                if (attacker != null && usesClaws)
                {
                    yield return new LogRecord($"{attacker.FormattedName} uses Claws to reduce opponents armour to 7.");
                }

                if (report.armorBroken)
                {
                    yield return new LogRecord($"The armour of {defender.FormattedName} has been broken.");
                }
                else
                {
                    yield return new LogRecord($"{defender.FormattedName} has been saved by {defender.Gender.Genetive} armour.");
                }
            }

            if (report.armorBroken && report.injuryRoll?.Length > 0)
            {
                yield return new LogRecord($"<b>Injury Roll [ {report.injuryRoll[0]} ][ {report.injuryRoll[1]} ]</b>");

                //
                // TODO: Incomplete
                //
            }

            yield return new LogRecord($"* * * Incomplete Report Handler (injury) * * *");

        }
    }
}
