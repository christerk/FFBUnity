namespace Fumbbl.Ffb.Dto.Reports
{
    public class ApothecaryChoice : Report
    {
        public string reportId;
        public string playerId;
        public int? playerState;
        public FFBEnumeration seriousInjury;

        public ApothecaryChoice() : base("apothecaryChoice") { }
    }
}
