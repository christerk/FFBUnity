namespace Fumbbl.Ffb.Dto.Reports
{
    public class FanFactorRoll : Report
    {
        public FanFactorRoll() : base("fanFactorRoll") { }

        public string reportId;
        public int[] fanFactorRollHome;
        public int fanFactorModifierHome;
        public int[] fanFactorRollAway;
        public int fanFactorModifierAway;
    }
}
