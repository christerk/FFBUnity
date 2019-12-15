namespace Fumbbl.Ffb.Dto.Reports
{
    public class RawString : Report
    {
        public string text;

        public RawString() : base("") { }

        internal static Report Create(string str)
        {
            return new RawString() { text = str };
        }
    }
}
