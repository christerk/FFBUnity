namespace Fumbbl.Ffb.Dto.Reports
{
    public class PassBlock : Report
    {
        public PassBlock() : base("passBlock") { }

        public string reportId;
        public string teamId;
        public bool passBlockAvailable;
    }
}
