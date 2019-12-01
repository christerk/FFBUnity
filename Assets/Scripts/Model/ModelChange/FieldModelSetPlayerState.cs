﻿using Fumbbl.Model.Types;

namespace Fumbbl.Model.ModelChange
{
    public class FieldModelSetPlayerState : ModelUpdater<Ffb.Dto.ModelChanges.FieldModelSetPlayerState>
    {
        public FieldModelSetPlayerState() : base(typeof(Ffb.Dto.ModelChanges.FieldModelSetPlayerState)) { }

        public override void Apply(Ffb.Dto.ModelChanges.FieldModelSetPlayerState change)
        {
            Player p = FFB.Instance.Model.GetPlayer(change.modelChangeKey);
            PlayerState state = PlayerState.Get(change.modelChangeValue);
            p.PlayerState = state;
        }
    }
}
