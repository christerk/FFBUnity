using Fumbbl.Model.Types;
using UnityEngine;

namespace Fumbbl.Model.ModelChange
{
    public class FieldModelSetBallMoving : ModelUpdater<Ffb.Dto.ModelChanges.FieldModelSetBallMoving>
    {
        public FieldModelSetBallMoving() : base(typeof(Ffb.Dto.ModelChanges.FieldModelSetBallMoving)) { }

        public override void Apply(Ffb.Dto.ModelChanges.FieldModelSetBallMoving change)
        {
            FFB.Instance.Model.Ball.Moving = change.modelChangeValue;
        }
    }
}
