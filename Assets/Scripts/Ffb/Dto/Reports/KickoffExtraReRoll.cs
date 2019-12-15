namespace Fumbbl.Ffb.Dto.Reports
{
    public class KickoffExtraReRoll : Report
    {
        public string reportId;
        public string kickoffResult;
        public int rollHome;
        public bool homeGainsReRoll;
        public int rollAway;
        public bool awayGainsReRoll;

        public KickoffExtraReRoll() : base("extraReRoll") { }
    }
}
