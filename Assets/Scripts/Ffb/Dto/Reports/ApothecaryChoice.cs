namespace Fumbbl.Dto.Reports
{
    public class ApothecaryChoice : Report
    {
        public ApothecaryChoice() : base("apothecaryChoice") { }

        public string reportId;
        public string playerId;
        public string playerState;
        public string seriousInjury;
    }
}
