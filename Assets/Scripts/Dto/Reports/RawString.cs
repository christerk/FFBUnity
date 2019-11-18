namespace Fumbbl.Dto.Reports
{
    public class RawString : IReport
    {
        public string text;

        internal static IReport Create(string str)
        {
            return new RawString() { text = str };
        }
    }
}
