namespace Fumbbl.Ffb.Dto.Reports
{
    public class ThrowIn : Report
    {
        public string reportId;
        public string direction;
        public int directionRoll;
        public int[] distanceRoll;

        public ThrowIn() : base("throwIn") { }
    }
}
