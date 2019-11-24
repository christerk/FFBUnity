namespace Fumbbl.Ffb.Dto.Reports
{
    public class KickoffExtraReRoll : Report
    {
        public KickoffExtraReRoll() : base("extraReRoll") { }

        public string reportId;
        public string kickoffResult;
        public int rollHome;
        public bool homeGainsReRoll;
        public int rollAway;
        public bool awayGainsReRoll;
    }
}
