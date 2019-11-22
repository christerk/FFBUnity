namespace Fumbbl.Ffb.Dto.Reports
{
    public class RawString : Report
    {
        public RawString() : base("") { }

        public string text;

        internal static Report Create(string str)
        {
            return new RawString() { text = str };
        }
    }
}
