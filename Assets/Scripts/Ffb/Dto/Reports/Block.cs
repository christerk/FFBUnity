namespace Fumbbl.Dto.Reports
{
    [ProtocolId("block")]
    public class Block : IReport
    {
        public string reportId;
        public string defenderId;
    }
}
