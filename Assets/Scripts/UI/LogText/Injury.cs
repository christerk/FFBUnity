using Fumbbl.Model;
using Fumbbl.Model.RollModifier;
using System.Collections.Generic;
using System.Linq;

namespace Fumbbl.UI.LogText
{
    public class Injury : LogTextGenerator<Ffb.Dto.Reports.Injury>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.Injury report)
        {
            Model.Types.Player attacker = FFB.Instance.Model.GetPlayer(report.attackerId);
            Model.Types.Player defender = FFB.Instance.Model.GetPlayer(report.defenderId);

            IEnumerable<ArmorModifier> armorModifiers = report.armorModifiers?.Select(r => r.As<ArmorModifier>());
            IEnumerable<InjuryModifier> injuryModifiers = report.injuryModifiers?.Select(r => r.As<InjuryModifier>());

            Model.Types.PlayerState playerState = Model.Types.PlayerState.Get(report.injury);
            var seriousInjury = report.seriousInjury.As<Model.Types.SeriousInjury>();

            string totalArmorText = "";
            string totalInjuryText = "";

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
                int totalArmorRoll = report.armorRoll.Sum();
                yield return new LogRecord($"<b>Armour Roll {CreateRollString(report.armorRoll)}</b>");
                totalArmorText += $"Rolled Total of {totalArmorRoll}";
                totalArmorText += string.Join("", armorModifiers.Select(m => m.ModifierString));
                int armorModifiersSum = armorModifiers.Sum(m => m.Modifier);
                if (armorModifiersSum != 0)
                {
                    totalArmorText += $" = {totalArmorRoll + armorModifiersSum}";
                }
                yield return new LogRecord(totalArmorText, 1);

                if (attacker != null && armorModifiers.Contains(ArmorModifier.Claws))
                {
                    yield return new LogRecord($"{attacker.FormattedName} uses Claws to reduce opponents armour to 7.", 1);
                }

                if (report.armorBroken)
                {
                    yield return new LogRecord($"The armour of {defender.FormattedName} has been broken.", 1);
                }
                else
                {
                    yield return new LogRecord($"{defender.FormattedName} has been saved by {defender.Gender.Genetive} armour.", 1);
                }
            }

            if (report.armorBroken && report.injuryRoll?.Length > 0)
            {
                int totalInjuryRoll = report.injuryRoll.Sum();
                yield return new LogRecord($"<b>Injury Roll {CreateRollString(report.injuryRoll)}</b>");
                totalInjuryText += $"Rolled Total of {totalInjuryRoll}";
                totalInjuryText += string.Join("", injuryModifiers.Select(m => m.ModifierString));
                int injuryModifiersSum = injuryModifiers.Sum(m => m.Modifier);
                if (injuryModifiersSum != 0)
                {
                    totalInjuryText += $" = {totalInjuryRoll + injuryModifiersSum}";
                }
                yield return new LogRecord(totalInjuryText, 1);

                if (injuryModifiers.Contains(InjuryModifier.Stunty))
                {
                    yield return new LogRecord($"{defender.FormattedName} is Stunty and more easily hurt because of that.", 1);
                }

                if (injuryModifiers.Contains(InjuryModifier.ThickSkull))
                {
                    yield return new LogRecord($"{defender.FormattedName}'s Thick Skull helps {defender.Gender.Dative} to stay on the pitch.", 1);
                }
            }

            if (report.casualtyRoll?.Length > 0)
            {
                yield return new LogRecord($"{defender.FormattedName} suffers a casualty.", 1);
                yield return new LogRecord($"<b>Casualty Roll [ {CreateRollString(report.casualtyRoll)}</b>");
                yield return new LogRecord($"{defender.FormattedName} {playerState.Description}.", 1);
                if (seriousInjury != null)
                {
                    yield return new LogRecord($"{defender.FormattedName} {seriousInjury.Description}.", 1);
                }
                if (report.casualtyRollDecay?.Length > 0)
                {
                    yield return new LogRecord($"{defender.FormattedName}'s body is decaying and {defender.Gender.Nominative} suffers a 2nd casualty.", 1);
                    yield return new LogRecord($"<b>Casualty Roll {CreateRollString(report.casualtyRollDecay)}</b>");
                    yield return new LogRecord($"{defender.FormattedName} {playerState.Description}.", 1);
                    if (seriousInjury != null)
                    {
                        yield return new LogRecord($"{defender.FormattedName} {seriousInjury.Description}.", 1);
                    }
                }
            }
            else
            {
                yield return new LogRecord($"{defender.FormattedName} {playerState.Description}.", 1);
                if (seriousInjury != null)
                {
                    yield return new LogRecord($"{defender.FormattedName} {seriousInjury.Description}.", 1);
                }
            }
        }
    }
}
