namespace Fumbbl.Ffb.Dto.Reports
{
    public class ScatterPlayer : Report
    {
        public string reportId;
        public int[] startCoordinate;
        public int[] endCoordinate;
        public string[] directionArray;
        public int[] rolls;

        public ScatterPlayer() : base("scatterPlayer") { }
    }
}
