using Fumbbl.Dto;

namespace Fumbbl.UI.LogText
{
    public class RawString : LogTextGenerator
    {
        public RawString() : base(typeof(Dto.Reports.RawString)) { }

        public override string Convert(Report report)
        {
            return ((Dto.Reports.RawString)report).text;
        }
    }
}
