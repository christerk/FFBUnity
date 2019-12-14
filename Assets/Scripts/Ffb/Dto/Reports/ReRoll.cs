namespace Fumbbl.Ffb.Dto.Reports
{
    public class ReRoll : Report
    {
        public string reportId;
        public string playerId;
        public string reRollSource;
        public bool successful;
        public int roll;

        public ReRoll() : base("reRoll") { }
    }
}
