namespace Fumbbl.Ffb.Dto.Reports
{
    public class KickoffResult : Report
    {
        public string reportId;
        public FFBEnumeration kickoffResult;
        public int[] kickoffRoll;

        public KickoffResult() : base("kickoffResult") { }
    }
}
