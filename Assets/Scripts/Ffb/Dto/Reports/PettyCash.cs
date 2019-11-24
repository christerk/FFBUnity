namespace Fumbbl.Ffb.Dto.Reports
{
    public class PettyCash : Report
    {
        public PettyCash() : base("pettyCash") { }

        public string reportId;
        public string teamId;
        public int gold;
    }
}
