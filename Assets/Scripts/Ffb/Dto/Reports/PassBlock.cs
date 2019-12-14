namespace Fumbbl.Ffb.Dto.Reports
{
    public class PassBlock : Report
    {
        public string reportId;
        public string teamId;
        public bool passBlockAvailable;

        public PassBlock() : base("passBlock") { }
    }
}
