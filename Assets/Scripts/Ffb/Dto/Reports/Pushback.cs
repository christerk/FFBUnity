namespace Fumbbl.Ffb.Dto.Reports
{
    public class Pushback : Report
    {
        public string reportId;
        public string defenderId;
        public string pushbackMode;

        public Pushback() : base("pushback") { }
    }
}
