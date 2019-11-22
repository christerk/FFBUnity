using System;

namespace Fumbbl.Model
{
    public abstract class ModelUpdater : ReflectedGenerator<Type>
    {
        public ModelUpdater(Type t) : base(t) { }

        public abstract void Apply(Ffb.Dto.ModelChange modelChange);
    }
}