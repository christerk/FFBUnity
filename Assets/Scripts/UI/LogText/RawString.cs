using Fumbbl.Dto;

namespace Fumbbl.UI.LogText
{
    [ReportType(typeof(Dto.Reports.RawString))]
    public class RawString : ILogTextGenerator
    {
        public string Convert(IReport report)
        {
            return ((Dto.Reports.RawString)report).text;
        }
    }
}
