namespace Fumbbl.Ffb.Dto.Reports
{
    public class KickoffRiot : Report
    {
        public string reportId;
        public int roll;
        public int turnModifier;

        public KickoffRiot() : base("kickoffRiot") { }
    }
}
