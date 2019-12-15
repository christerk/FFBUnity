namespace Fumbbl.Ffb.Dto.Reports
{
    public class MostValuablePlayers : Report
    {
        public string reportId;
        public string[] playerIdsHome;
        public string[] playerIdsAway;

        public MostValuablePlayers() : base("mostValuablePlayers") { }
    }
}
