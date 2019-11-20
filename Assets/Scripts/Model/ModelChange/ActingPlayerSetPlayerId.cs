using Fumbbl.Dto;
using UnityEngine;

namespace Fumbbl.Model.ModelChange
{
    public class ActingPlayerSetPlayerId : ModelUpdater
    {
        public ActingPlayerSetPlayerId() : base(typeof(Dto.ModelChanges.ActingPlayerSetPlayerId)) { }

        public override void Apply(Dto.ModelChange modelChange)
        {
            var change = (Dto.ModelChanges.ActingPlayerSetPlayerId)modelChange;

            FFB.Instance.Model.ActingPlayer.PlayerId = change.modelChangeValue;
            Debug.Log($"Setting Acting Player to {change.modelChangeValue}");
        }
    }
}
