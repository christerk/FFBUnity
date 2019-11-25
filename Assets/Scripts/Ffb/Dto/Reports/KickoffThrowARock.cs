namespace Fumbbl.Ffb.Dto.Reports
{
    public class KickoffThrowARock : Report
    {
        public KickoffThrowARock() : base("kickoffThrowARock") { }

        public string reportId;
        public int rollHome;
        public int rollAway;
        public string[] playerIdsHit;
    }
}
