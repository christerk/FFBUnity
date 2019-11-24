namespace Fumbbl.Ffb.Dto.Reports
{
    public class PenaltyShootout : Report
    {
        public PenaltyShootout() : base("penaltyShootout") { }

        public string reportId;
        public int rollHome;
        public int reRollsLeftHome;
        public int rollAway;
        public int reRollsLeftAway;
    }
}
