namespace Fumbbl.Ffb.Dto.Reports
{
    public class MostValuablePlayers : Report
    {
        public MostValuablePlayers() : base("mostValuablePlayers") { }

        public string reportId;
        public string[] playerIdsHome;
        public string[] playerIdsAway;
    }
}
