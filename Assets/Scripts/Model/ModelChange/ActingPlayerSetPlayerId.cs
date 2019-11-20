using UnityEngine;

namespace Fumbbl.Model.ModelChange
{
    public class ActingPlayerSetPlayerId : ModelUpdater
    {
        public ActingPlayerSetPlayerId() : base(typeof(Ffb.Dto.ModelChanges.ActingPlayerSetPlayerId)) { }

        public override void Apply(Ffb.Dto.ModelChange modelChange)
        {
            var change = (Ffb.Dto.ModelChanges.ActingPlayerSetPlayerId)modelChange;

            FFB.Instance.Model.ActingPlayer.PlayerId = change.modelChangeValue;
            Debug.Log($"Setting Acting Player to {change.modelChangeValue}");
        }
    }
}
