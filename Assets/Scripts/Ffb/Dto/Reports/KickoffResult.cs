namespace Fumbbl.Ffb.Dto.Reports
{
    public class KickoffResult : Report
    {
        public KickoffResult() : base("kickoffResult") { }

        public string reportId;
        public FFBEnumeration kickoffResult;
        public int[] kickoffRoll;
    }
}
