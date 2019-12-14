namespace Fumbbl.Ffb.Dto.Reports
{
    public class BribesRoll : Report
    {
        public string reportId;
        public string playerId;
        public bool successful;
        public int roll;

        public BribesRoll() : base("bribesRoll") { }
    }
}
