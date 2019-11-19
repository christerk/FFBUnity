using Fumbbl.Dto;
using UnityEngine;

namespace Fumbbl.Model.ModelChange
{
    [ModelChange(typeof(Dto.ModelChanges.ActingPlayerSetPlayerId))]
    public class ActingPlayerSetPlayerId : IModelUpdater
    {
        public void Apply(IModelChange modelChange)
        {
            var change = (Dto.ModelChanges.ActingPlayerSetPlayerId)modelChange;

            FFB.Instance.Model.ActingPlayer.PlayerId = change.modelChangeValue;
            Debug.Log($"Setting Acting Player to {change.modelChangeValue}");
        }
    }
}
