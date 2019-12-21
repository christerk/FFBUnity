using Fumbbl.Model.Types;
using System.Collections.Generic;
using System.Linq;

namespace Fumbbl.UI.LogText
{
    public class CoinThrow : LogTextGenerator<Ffb.Dto.Reports.CoinThrow>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.CoinThrow report)
        {
            yield return new LogRecord($"<b>The referee throws the coin.</b>");
            string throwResult = report.coinThrowHeads ? "Heads" : "Tails";
            string throwChoice = report.coinChoiceHeads ? "Heads" : "Tails";
            yield return new LogRecord($"Coach {report.coach} chooses {throwChoice}.", 1);
            yield return new LogRecord($"Coin throw is {throwResult}.", 1);
        }

    }
}
