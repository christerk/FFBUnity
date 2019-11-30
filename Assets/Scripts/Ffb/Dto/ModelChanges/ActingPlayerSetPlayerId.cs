namespace Fumbbl.Ffb.Dto.ModelChanges
{
    public class ActingPlayerSetPlayerId : ModelChange
    {
        public string modelChangeId;
        public string modelChangeValue;

        public ActingPlayerSetPlayerId() : base("actingPlayerSetPlayerId")
        {
        }
    }
}
