using System;
using Assets.Scripts.Model;

namespace Fumbbl.Model
{
    public class Core
    {
        //private ModelChangeFactory ModelChangeFactory { get; }
        private ReflectedFactory<ModelUpdater, Type> ModelChangeFactory { get; }
        public ActingPlayer ActingPlayer { get; }

        public Core()
        {
            //ModelChangeFactory = new ModelChangeFactory();
            ModelChangeFactory = new ReflectedFactory<ModelUpdater, Type>();
            ActingPlayer = new ActingPlayer();
        }

        internal void ApplyChange(Ffb.Dto.ModelChange change)
        {
            //IModelUpdater updater = ModelChangeFactory.Create(change);
            ModelUpdater updater = ModelChangeFactory.GetReflectedInstance(change.GetType());
            updater?.Apply(change);
        }

        internal Player GetPlayer(string playerId)
        {
            return new Player()
            {
                Id = playerId,
                Name = playerId,
                Gender = Gender.Male
            };
        }
    }
}