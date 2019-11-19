using Fumbbl.Dto.Reports;

namespace Fumbbl.Dto.ModelChanges
{
    [ProtocolId("actingPlayerSetPlayerId")]
    class ActingPlayerSetPlayerId : IModelChange
    {
        public string modelChangeId;
        public string modelChangeValue;
    }
}
