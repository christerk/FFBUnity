using System.Collections.Generic;

namespace Fumbbl.UI.LogText
{
    public class RawString : LogTextGenerator<Ffb.Dto.Reports.RawString>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.RawString report)
        {
            yield return new LogRecord(report.text);
        }
    }
}
