﻿using System;

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

        internal string GetPlayerName(string playerId)
        {
            return playerId;
        }

        internal void ApplyChange(Ffb.Dto.ModelChange change)
        {
            //IModelUpdater updater = ModelChangeFactory.Create(change);
            ModelUpdater updater = ModelChangeFactory.GetReflectedInstance(change.GetType());
            updater?.Apply(change);
        }
    }
}