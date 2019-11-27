namespace Fumbbl.Ffb.Dto.ModelChanges
{
    class FieldModelSetPlayerCoordinate : ModelChange
    {
        public string modelChangeId;
        public string modelChangeKey;
        public int[] modelChangeValue;

        public FieldModelSetPlayerCoordinate() : base("fieldModelSetPlayerCoordinate")
        {
        }
    }
}
