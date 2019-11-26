namespace Fumbbl.Ffb.Dto.Reports
{
    public class TurnEnd : Report
    {
        public TurnEnd() : base("turnEnd") { }
        public string reportId;
        public string playerIdTouchdown;
        public string[] knockoutRecoveries;
        public string[] heatExhaustions;
    }
}