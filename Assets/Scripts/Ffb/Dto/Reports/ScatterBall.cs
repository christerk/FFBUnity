namespace Fumbbl.Ffb.Dto.Reports
{
    public class ScatterBall : Report
    {
        public string reportId;
        public string[] directionArray;
        public int[] rolls;
        public bool gustOfWind;

        public ScatterBall() : base("scatterBall") { }
    }
}
