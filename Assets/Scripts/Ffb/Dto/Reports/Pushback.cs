namespace Fumbbl.Ffb.Dto.Reports
{
    public class Pushback : Report
    {
        public Pushback() : base("pushback") { }

        public string reportId;
        public string defenderId;
        public string pushbackMode;
    }
}
