namespace Fumbbl.Ffb.Dto.Reports
{
    public class Weather : Report
    {
        public string reportId;
        public string weather;
        public int[] weatherRoll;

        public Weather() : base("weather") { }
    }
}
