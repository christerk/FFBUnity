namespace Fumbbl.Ffb.Dto.Reports
{
    public class Foul : Report
    {
        public Foul() : base("foul") { }

        public string reportId;
        public string defenderId;
    }
}
