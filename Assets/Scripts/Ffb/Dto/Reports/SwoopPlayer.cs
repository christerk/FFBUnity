namespace Fumbbl.Ffb.Dto.Reports
{
    public class SwoopPlayer : Report
    {
        public string reportId;
        public string startCoordinate;
        public string endCoordinate;
        public string[] directionArray;
        public int[] rolls;

        public SwoopPlayer() : base("swoopPlayer") { }
    }
}
