namespace Fumbbl.Ffb.Dto.ModelChanges
{
    public class FieldModelSetBallInPlay : ModelChange
    {
        public string modelChangeId;
        public string modelChangeKey;
        public bool modelChangeValue;

        public FieldModelSetBallInPlay() : base("fieldModelSetBallInPlay")
        {
        }
    }
}
