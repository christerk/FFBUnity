namespace Fumbbl.Ffb.Dto.Reports
{
    public class TimeoutEnforced : Report
    {
        public string reportId;
        public string coach;

        public TimeoutEnforced() : base("timeoutEnforced") { }
    }
}
