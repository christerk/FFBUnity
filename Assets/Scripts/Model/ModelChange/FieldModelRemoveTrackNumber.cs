using Fumbbl.Ffb.Conversion;

namespace Fumbbl.Model.ModelChange
{
    public class FieldModelRemoveTrackNumber : ModelUpdater<Ffb.Dto.ModelChanges.FieldModelRemoveTrackNumber>
    {
        public FieldModelRemoveTrackNumber() : base(typeof(Ffb.Dto.ModelChanges.FieldModelRemoveTrackNumber)) { }

        public override void Apply(Ffb.Dto.ModelChanges.FieldModelRemoveTrackNumber change)
        {
            FFB.Instance.Model.RemoveTrackNumber(TrackNumberFactory.TrackNumber(change.modelChangeValue));
        }
    }
}
