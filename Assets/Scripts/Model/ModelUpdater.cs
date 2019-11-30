using System;

namespace Fumbbl.Model
{
    public abstract class ModelUpdater<T> : ReflectedGenerator<Type>
        where T : Ffb.Dto.ModelChange
    {
        public ModelUpdater(Type t) : base(t) { }

        public ModelUpdater<Ffb.Dto.ModelChange> AsGenericGenerator()
        {
            return this.CastGenerator<T, Ffb.Dto.ModelChange> ();
        }

        public abstract void Apply(T modelChange);

    }

    internal class CastedModelUpdater<TTo, TFrom> : ModelUpdater<TTo>
        where TTo : Ffb.Dto.ModelChange
        where TFrom : Ffb.Dto.ModelChange
    {
        private readonly ModelUpdater<TFrom> Generator;
        public CastedModelUpdater(ModelUpdater<TFrom> generator)
            : base(typeof(TFrom))
        {
            Generator = generator;
        }

        public override void Apply(TTo report)
        {
            Generator.Apply(report as TFrom);
        }
    }

    public static class ModelUpdaterExtensions
    {
        public static ModelUpdater<TTo> CastGenerator<TFrom, TTo>(this ModelUpdater<TFrom> generator)
            where TTo : Ffb.Dto.ModelChange
            where TFrom : Ffb.Dto.ModelChange
        {
            return new CastedModelUpdater<TTo, TFrom>(generator);
        }
    }
}