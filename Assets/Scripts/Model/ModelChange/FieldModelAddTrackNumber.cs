using Fumbbl.Ffb.Conversion;

namespace Fumbbl.Model.ModelChange
{
    public class FieldModelAddTrackNumber : ModelUpdater<Ffb.Dto.ModelChanges.FieldModelAddTrackNumber>
    {
        public FieldModelAddTrackNumber() : base(typeof(Ffb.Dto.ModelChanges.FieldModelAddTrackNumber)) { }

        public override void Apply(Ffb.Dto.ModelChanges.FieldModelAddTrackNumber change)
        {
            FFB.Instance.Model.Add(TrackNumberFactory.TrackNumber(change.modelChangeValue));
        }
    }
}
