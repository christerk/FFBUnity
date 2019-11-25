namespace Fumbbl.Ffb.Dto.Reports
{
    public class KickoffRiot : Report
    {
        public KickoffRiot() : base("kickoffRiot") { }

        public string reportId;
        public int roll;
        public int turnModifier;
    }
}
