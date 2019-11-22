namespace Fumbbl.Ffb.Dto.ModelChanges
{
    class ActingPlayerSetPlayerId : ModelChange
    {
        public string modelChangeId;
        public string modelChangeValue;

        public ActingPlayerSetPlayerId() : base("actingPlayerSetPlayerId")
        {
        }
    }
}
