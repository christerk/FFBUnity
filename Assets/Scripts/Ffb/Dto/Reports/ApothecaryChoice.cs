namespace Fumbbl.Ffb.Dto.Reports
{
    public class ApothecaryChoice : Report
    {
        public ApothecaryChoice() : base("apothecaryChoice") { }

        public string reportId;
        public string playerId;
        public int? playerState;
        public FFBEnumeration seriousInjury;
    }
}
