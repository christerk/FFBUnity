using Fumbbl.Dto;
using System;

namespace Fumbbl.Model
{
    public class Model
    {
        private ModelChangeFactory ModelChangeFactory { get; }
        public ActingPlayer ActingPlayer { get; }

        public Model()
        {
            ModelChangeFactory = new ModelChangeFactory();
            ActingPlayer = new ActingPlayer();
        }

        internal string GetPlayerName(string playerId)
        {
            return playerId;
        }

        internal void ApplyChange(IModelChange change)
        {
            IModelUpdater updater = ModelChangeFactory.Create(change);
            updater?.Apply(change);
        }
    }
}