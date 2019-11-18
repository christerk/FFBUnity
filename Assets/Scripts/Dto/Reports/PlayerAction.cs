namespace Fumbbl.Dto.Reports
{
    [ProtocolId("playerAction")]
    public class PlayerAction : IReport
    {
        public string reportId;
        public string actingPlayerId;
        public string playerAction;
    }
}
