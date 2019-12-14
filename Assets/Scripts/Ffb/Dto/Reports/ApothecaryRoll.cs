namespace Fumbbl.Ffb.Dto.Reports
{
    public class ApothecaryRoll : Report
    {
        public string reportId;
        public string playerId;
        public int[] casualtyRoll;
        public int? playerState;
        public string seriousInjury;

        public ApothecaryRoll() : base("apothecaryRoll") { }
    }
}
