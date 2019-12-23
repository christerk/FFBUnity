using Fumbbl.Model;
using System.Collections.Generic;

namespace Fumbbl.UI.LogText
{
    public class CardEffectRoll : LogTextGenerator<Ffb.Dto.Reports.CardEffectRoll>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.CardEffectRoll report)
        {
            var card = report.card.As<Model.Types.Card>();
            var cardEffect = report.cardEffect.As<Model.Types.CardEffect>();

            if (card == Model.Types.Card.WitchsBrew)
            {
                yield return new LogRecord($"<b>Witch Brew Roll [ {report.roll} ]</b>");
                if (cardEffect == Model.Types.CardEffect.Sedative)
                {
                     yield return new LogRecord($"Sedative! The player gains the Really Stupid skill until the drive ends.", 1);
                }
                else if (cardEffect == Model.Types.CardEffect.MadCapMushroomPotion)
                {
                    yield return new LogRecord($"Mad Cap Mushroom potion! The player gains the Jump Up and No Hands skills until the drive ends.", 1);
                }
                else
                {
                    yield return new LogRecord($"Snake Oil! Bad taste, but no effect.", 1);
                }
            }
        }
    }
}
