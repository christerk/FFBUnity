namespace Fumbbl.Ffb.Dto.Reports
{
    public class FanFactorRoll : Report
    {
        public string reportId;
        public int[] fanFactorRollHome;
        public int fanFactorModifierHome;
        public int[] fanFactorRollAway;
        public int fanFactorModifierAway;

        public FanFactorRoll() : base("fanFactorRoll") { }
    }
}
