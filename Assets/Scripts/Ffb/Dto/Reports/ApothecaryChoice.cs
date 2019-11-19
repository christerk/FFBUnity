namespace Fumbbl.Dto.Reports
{
    [ProtocolId("apothecaryChoicex")]
    public class ApothecaryChoice : IReport
    {
        public string reportId;
        public string playerId;
        public string playerState;
        public string seriousInjury;
    }
}
