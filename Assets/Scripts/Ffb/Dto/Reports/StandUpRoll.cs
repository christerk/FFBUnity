namespace Fumbbl.Ffb.Dto.Reports
{
    public class StandUpRoll : Report
    {
        public string reportId;
        public string playerId;
        public bool successful;
        public int roll;
        public int modifier;
        public bool reRolled;

        public StandUpRoll() : base("standUpRoll") { }
    }
}
