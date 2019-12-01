using Fumbbl.Model.Types;
using System.Collections.Generic;
using System;
using Fumbbl.Model.RollModifier;

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
                yield return new LogRecord($"<b>Rolled Total of {report.armorRoll[0] + report.armorRoll[1]}</b>");

                int armorModifierTotal = 0;
                int i = 0;

                var status = "";
                int rolledTotal = report.armorRoll[0] + report.armorRoll[1];

                foreach (FFBEnumeration entry in report.armorModifiers)
                {
                   var armourModifier = entry.AsArmorModifier();
                    i = i | ((armourModifier == ArmorModifier.Claws ? 1 : 0));
                    if (armourModifier.Modifier != 0)
                    {
                        armorModifierTotal += armourModifier.Modifier;

                        status += armourModifier.Modifier > 0 ? " + " : " - ";

                        if (!armourModifier.FoulAssistModifier)
                        {
                            status += Math.Abs(armourModifier.Modifier).ToString() + " ";
                        }
                    
                        status += armourModifier.Name;
                    }
                }

                if (armorModifierTotal != 0)
                {
                    var sumTotal = rolledTotal + armorModifierTotal;
                    status += " = " + sumTotal;
                }
                
                yield return new LogRecord(status);
                
                if (attacker != null && i != 0) {
                    yield return new LogRecord(attacker.FormattedName + " uses Claws to reduce opponents armour to 7.");
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
