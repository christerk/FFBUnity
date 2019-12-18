using Fumbbl.Model.Types;
using System.Collections.Generic;

namespace Fumbbl.UI.LogText
{
    public class FumbblResultUpload : LogTextGenerator<Ffb.Dto.Reports.FumbblResultUpload>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.FumbblResultUpload report)
        {
            yield return new LogRecord($"<b>Fumbbl Result Upload: {Result(report.successful)}</b>");
            yield return new LogRecord($"{report.uploadStatus}");
        }

        private string Result(bool res)
        {
            return res ? "ok" : "failed";
        }
    }
}
