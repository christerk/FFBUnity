namespace Fumbbl.Ffb.Dto.ModelChanges
{
    public class FieldModelSetBallCoordinate : ModelChange
    {
        public string modelChangeId;
        public string modelChangeKey;
        public int[] modelChangeValue;

        public FieldModelSetBallCoordinate() : base("fieldModelSetBallCoordinate")
        {
        }
    }
}
