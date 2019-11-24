namespace Fumbbl.Ffb.Dto.Reports
{
    public class ScatterBall : Report
    {
        public ScatterBall() : base("scatterBall") { }

        public string reportId;
        public string[] directionArray;
        public int[] rolls;
        public bool gustOfWind;
    }
}
