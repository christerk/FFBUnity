namespace Fumbbl.Model.ModelChange
{
    public class FieldModelAddMoveSquare : ModelUpdater<Ffb.Dto.ModelChanges.FieldModelAddMoveSquare>
    {
        public FieldModelAddMoveSquare() : base(typeof(Ffb.Dto.ModelChanges.FieldModelAddMoveSquare)) { }

        public override void Apply(Ffb.Dto.ModelChanges.FieldModelAddMoveSquare change)
        {
            FFB.Instance.Model.Add(change.modelChangeValue);
        }
    }
}
