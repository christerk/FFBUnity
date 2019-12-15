namespace Fumbbl.Ffb.Dto.Reports
{
    public class TurnEnd : Report
    {
        public string reportId;
        public string playerIdTouchdown;
        public KnockoutRecoveryResult[] knockoutRecoveryArray;
        public HeatExhaustionResult[] heatExhaustionArray;

        public TurnEnd() : base("turnEnd") { }
    }
}
