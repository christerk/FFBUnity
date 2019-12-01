using Fumbbl.Model.Types;
using System.Collections.Generic;
using System.Linq;

namespace Fumbbl.UI.LogText
{
    public class BlockRoll : LogTextGenerator<Ffb.Dto.Reports.BlockRoll>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.BlockRoll report)
        {
            yield return new LogRecord($"<b>Block Roll [ { string.Join(" ] [ ", report.blockRoll.Select(r => BlockDie.Get(r).Name)) } ]</b>");
        }
    }
}
