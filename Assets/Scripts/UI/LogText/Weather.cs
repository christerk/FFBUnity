using Fumbbl.Model.Types;
using System.Collections.Generic;
using System.Linq;

namespace Fumbbl.UI.LogText
{
    public class Weather : LogTextGenerator<Ffb.Dto.Reports.Weather>
    {

        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.Weather report)
        {
         
            yield return new LogRecord($"<b>Weather Roll {CreateRollString(report.weatherRoll)}</b>");
            yield return new LogRecord($"Weather is {report.weather}", 1);
        }
    }
}
