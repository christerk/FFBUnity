namespace Fumbbl.Ffb.Dto.Reports
{
    public class KickoffPitchInvasion : Report
    {
        public string reportId;
        public int[] rollsHome;
        public bool[] playersAffectedHome;
        public int[] rollsAway;
        public bool[] playersAffectedAway;

        public KickoffPitchInvasion() : base("kickoffPitchInvasion") { }
    }
}
