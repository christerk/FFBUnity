using Fumbbl.Dto;
using System;

namespace Fumbbl.Model
{
    public class Core
    {
        //private ModelChangeFactory ModelChangeFactory { get; }
        private ReflectedFactory<IModelUpdater, Type> ModelChangeFactory { get; }
        public ActingPlayer ActingPlayer { get; }

        public Core()
        {
            //ModelChangeFactory = new ModelChangeFactory();
            ModelChangeFactory = new ReflectedFactory<IModelUpdater, Type>(typeof(ModelChangeAttribute));
            ActingPlayer = new ActingPlayer();
        }

        internal string GetPlayerName(string playerId)
        {
            return playerId;
        }

        internal void ApplyChange(IModelChange change)
        {
            //IModelUpdater updater = ModelChangeFactory.Create(change);
            IModelUpdater updater = ModelChangeFactory.GetReflectedInstance(change.GetType());
            updater?.Apply(change);
        }
    }
}