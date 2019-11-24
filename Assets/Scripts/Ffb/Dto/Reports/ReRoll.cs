namespace Fumbbl.Ffb.Dto.Reports
{
    public class ReRoll : Report
    {
        public ReRoll() : base("reRoll") { }

        public string reportId;
        public string playerId;
        public string reRollSource;
        public bool successful;
        public int roll;
    }
}
