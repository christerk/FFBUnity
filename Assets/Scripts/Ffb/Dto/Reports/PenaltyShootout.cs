namespace Fumbbl.Ffb.Dto.Reports
{
    public class PenaltyShootout : Report
    {
        public string reportId;
        public int rollHome;
        public int reRollsLeftHome;
        public int rollAway;
        public int reRollsLeftAway;

        public PenaltyShootout() : base("penaltyShootout") { }
    }
}
