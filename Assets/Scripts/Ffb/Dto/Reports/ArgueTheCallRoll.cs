namespace Fumbbl.Ffb.Dto.Reports
{
    public class ArgueTheCallRoll : Report
    {
        public ArgueTheCallRoll() : base("argueTheCall") { }

        public string reportId;
        public string playerId;
        public bool successful;
        public bool coachBanned;
        public int roll;
    }
}
