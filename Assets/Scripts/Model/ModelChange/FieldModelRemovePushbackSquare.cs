namespace Fumbbl.Model.ModelChange
{
    public class FieldModelRemovePushbackSquare : ModelUpdater<Ffb.Dto.ModelChanges.FieldModelRemovePushbackSquare>
    {
        public FieldModelRemovePushbackSquare() : base(typeof(Ffb.Dto.ModelChanges.FieldModelRemovePushbackSquare)) { }

        public override void Apply(Ffb.Dto.ModelChanges.FieldModelRemovePushbackSquare change)
        {
            FFB.Instance.Model.RemovePushbackSquare(change.modelChangeValue);
        }
    }
}
