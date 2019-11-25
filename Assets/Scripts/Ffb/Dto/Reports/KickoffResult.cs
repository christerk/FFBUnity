namespace Fumbbl.Ffb.Dto.Reports
{
    public class KickoffResult : Report
    {
        public KickoffResult() : base("kickoffResult") { }

        public string reportId;
        public string kickoffResult;
        public int[] kickoffRoll;
    }
}
