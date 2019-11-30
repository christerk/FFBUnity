using Fumbbl.Model.Types;
using UnityEngine;

namespace Fumbbl.Model.ModelChange
{
    public class FieldModelSetBallInPlay : ModelUpdater<Ffb.Dto.ModelChanges.FieldModelSetBallInPlay>
    {
        public FieldModelSetBallInPlay() : base(typeof(Ffb.Dto.ModelChanges.FieldModelSetBallInPlay)) { }

        public override void Apply(Ffb.Dto.ModelChanges.FieldModelSetBallInPlay change)
        {
            FFB.Instance.Model.Ball.InPlay = change.modelChangeValue;
        }
    }
}
