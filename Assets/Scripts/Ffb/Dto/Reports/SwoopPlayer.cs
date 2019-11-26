namespace Fumbbl.Ffb.Dto.Reports
{
    public class SwoopPlayer : Report
    {
        public SwoopPlayer() : base("swoopPlayer") { }
        public string reportId;
        public string startCoordinate;
        public string endCoordinate;
        public string[] directionArray;
        public int[] rolls;
    }
}