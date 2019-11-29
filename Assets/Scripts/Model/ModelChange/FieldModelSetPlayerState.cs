using Fumbbl.Model.Types;
using UnityEngine;

namespace Fumbbl.Model.ModelChange
{
    public class FieldModelSetPlayerState : ModelUpdater
    {
        public FieldModelSetPlayerState() : base(typeof(Ffb.Dto.ModelChanges.FieldModelSetPlayerState)) { }

        public override void Apply(Ffb.Dto.ModelChange modelChange)
        {
            var change = (Ffb.Dto.ModelChanges.FieldModelSetPlayerState)modelChange;

            Player p = FFB.Instance.Model.GetPlayer(change.modelChangeKey);
            PlayerState state = PlayerState.Get(change.modelChangeValue);
            p.PlayerState = state;
        }
    }
}
