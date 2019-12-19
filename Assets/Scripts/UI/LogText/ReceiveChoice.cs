using Fumbbl.Model.Types;
using System.Collections.Generic;
using System.Linq;

namespace Fumbbl.UI.LogText
{
    public class ReceiveChoice : LogTextGenerator<Ffb.Dto.Reports.ReceiveChoice>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.ReceiveChoice report)
        {
            string kickorreceive = report.receiveChoice ? "receiving" : "kicking";
            yield return new LogRecord($"Team {report.receiveChoice} is {kickorreceive}.");
        }
    }
}
