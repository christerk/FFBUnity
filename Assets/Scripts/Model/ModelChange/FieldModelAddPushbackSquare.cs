using Fumbbl.Model.Types;
using UnityEngine;

namespace Fumbbl.Model.ModelChange
{
    public class FieldModelAddPushbackSquare : ModelUpdater<Ffb.Dto.ModelChanges.FieldModelAddPushbackSquare>
    {
        public FieldModelAddPushbackSquare() : base(typeof(Ffb.Dto.ModelChanges.FieldModelAddPushbackSquare)) { }

        public override void Apply(Ffb.Dto.ModelChanges.FieldModelAddPushbackSquare change)
        {
            FFB.Instance.Model.AddPushbackSquare(change.modelChangeValue);
        }
    }
}
