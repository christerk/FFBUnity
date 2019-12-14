namespace Fumbbl.Ffb.Dto.Reports
{
    public class PettyCash : Report
    {
        public string reportId;
        public string teamId;
        public int gold;

        public PettyCash() : base("pettyCash") { }
    }
}
