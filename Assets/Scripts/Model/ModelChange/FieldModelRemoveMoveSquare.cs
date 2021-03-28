using Fumbbl.Ffb.Conversion;

namespace Fumbbl.Model.ModelChange
{
    public class FieldModelRemoveMoveSquare : ModelUpdater<Ffb.Dto.ModelChanges.FieldModelRemoveMoveSquare>
    {
        public FieldModelRemoveMoveSquare() : base(typeof(Ffb.Dto.ModelChanges.FieldModelRemoveMoveSquare)) { }

        public override void Apply(Ffb.Dto.ModelChanges.FieldModelRemoveMoveSquare change)
        {
            FFB.Instance.Model.RemoveTrackNumber(TrackNumberFactory.TrackNumber(change.modelChangeValue));
        }
    }
}
