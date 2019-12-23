using Fumbbl.Model;
using System.Collections.Generic;

namespace Fumbbl.UI.LogText
{
    public class CardDeactivated : LogTextGenerator<Ffb.Dto.Reports.CardDeactivated>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.CardDeactivated report)
        {
            var card = report.card.As<Model.Types.Card>();

            yield return new LogRecord($"Card {card.Name} effect ended.");
        }
    }
}
