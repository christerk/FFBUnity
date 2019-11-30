using Fumbbl.Model.Types;
using UnityEngine;

namespace Fumbbl.Model.ModelChange
{
    public class FieldModelRemoveTrackNumber : ModelUpdater<Ffb.Dto.ModelChanges.FieldModelRemoveTrackNumber>
    {
        public FieldModelRemoveTrackNumber() : base(typeof(Ffb.Dto.ModelChanges.FieldModelRemoveTrackNumber)) { }

        public override void Apply(Ffb.Dto.ModelChanges.FieldModelRemoveTrackNumber change)
        {
            FFB.Instance.Model.RemoveTrackNumber(change.modelChangeValue);
        }
    }
}
