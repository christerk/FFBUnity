namespace Fumbbl.Ffb.Dto.Reports
{
    public class WinningsRoll : Report
    {
        public string reportId;
        public int winningsRollHome;
        public int winningsHome;
        public int winningsRollAway;
        public int winningsAway;

        public WinningsRoll() : base("winningsRoll") { }
    }
}
