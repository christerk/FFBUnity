namespace Fumbbl.Ffb.Dto.Reports
{
    public class ThrowIn : Report
    {
        public ThrowIn() : base("throwIn") { }
        public string reportId;
        public string direction;
        public int directionRoll;
        public int[] distanceRoll;
    }
}