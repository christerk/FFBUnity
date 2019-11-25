namespace Fumbbl.Ffb.Dto.Reports
{
    public class BribesRoll : Report
    {
        public BribesRoll() : base("bribesRoll") { }

        public string reportId;
        public string playerId;
        public bool successful;
        public int roll;
    }
}
