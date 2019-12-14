namespace Fumbbl.Ffb.Dto.Reports
{
    public class Foul : Report
    {
        public string reportId;
        public string defenderId;

        public Foul() : base("foul") { }
    }
}
