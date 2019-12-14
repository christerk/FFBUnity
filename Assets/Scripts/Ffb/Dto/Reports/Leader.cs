namespace Fumbbl.Ffb.Dto.Reports
{
    public class Leader : Report
    {
        public string reportId;
        public string teamId;
        public string leaderState;

        public Leader() : base("leader") { }
    }
}
