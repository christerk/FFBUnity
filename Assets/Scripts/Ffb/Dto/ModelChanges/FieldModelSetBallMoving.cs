namespace Fumbbl.Ffb.Dto.ModelChanges
{
    public class FieldModelSetBallMoving : ModelChange
    {
        public string modelChangeId;
        public string modelChangeKey;
        public bool modelChangeValue;

        public FieldModelSetBallMoving() : base("fieldModelSetBallMoving")
        {
        }
    }
}
