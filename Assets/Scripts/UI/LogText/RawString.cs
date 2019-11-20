using Fumbbl.Ffb.Dto;

namespace Fumbbl.UI.LogText
{
    public class RawString : LogTextGenerator
    {
        public RawString() : base(typeof(Ffb.Dto.Reports.RawString)) { }

        public override string Convert(Report report)
        {
            return ((Ffb.Dto.Reports.RawString)report).text;
        }
    }
}
