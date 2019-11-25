namespace Fumbbl.Ffb.Dto.Reports
{
    public class Injury : Report
    {
        public Injury() : base("injury") { }

        public string reportId;
        public string defenderId;
        public string injuryType;
        public bool armorBroken;
        public int[] armorRoll;
        public int[] injuryRoll;
        public int[] casualtyRoll;
        public string seriousInjury;
        public int[] casualtyRollDecay;
        public string seriousInjuryDecay;
        public int injury;
        public int? injuryDecay;
        public string attackerId;
        public string[] armorModifiers;
        public string[] injuryModifiers;
    }
}
