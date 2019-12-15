namespace Fumbbl.Ffb.Dto.Reports
{
    public class ArgueTheCallRoll : Report
    {
        public string reportId;
        public string playerId;
        public bool successful;
        public bool coachBanned;
        public int roll;

        public ArgueTheCallRoll() : base("argueTheCall") { }
    }
}
