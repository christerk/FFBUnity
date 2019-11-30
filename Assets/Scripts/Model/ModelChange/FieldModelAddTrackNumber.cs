using Fumbbl.Model.Types;
using UnityEngine;

namespace Fumbbl.Model.ModelChange
{
    public class FieldModelAddTrackNumber : ModelUpdater<Ffb.Dto.ModelChanges.FieldModelAddTrackNumber>
    {
        public FieldModelAddTrackNumber() : base(typeof(Ffb.Dto.ModelChanges.FieldModelAddTrackNumber)) { }

        public override void Apply(Ffb.Dto.ModelChanges.FieldModelAddTrackNumber change)
        {
            FFB.Instance.Model.AddTrackNumber(change.modelChangeValue);
        }
    }
}
