namespace Fumbbl.Ffb.Dto.Reports
{
    public class Leader : Report
    {
        public Leader() : base("leader") { }

        public string reportId;
        public string teamId;
        public string leaderState;
    }
}
