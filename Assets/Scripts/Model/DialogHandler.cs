using System;

namespace Fumbbl.Model
{
    public abstract class DialogHandler<T> : ReflectedGenerator<Type>
        where T : Ffb.Dto.FfbDialog
    {
        public DialogHandler(Type t) : base(t) { }

        public abstract void Apply(T dialog);

        public DialogHandler<Ffb.Dto.FfbDialog> AsGenericGenerator()
        {
            return this.CastGenerator<T, Ffb.Dto.FfbDialog>();
        }
    }

    public static class DialogHandlerExtensions
    {
        public static DialogHandler<TTo> CastGenerator<TFrom, TTo>(this DialogHandler<TFrom> generator)
            where TTo : Ffb.Dto.FfbDialog
            where TFrom : Ffb.Dto.FfbDialog
        {
            return new CastedDialogHandler<TTo, TFrom>(generator);
        }
    }

    internal class CastedDialogHandler<TTo, TFrom> : DialogHandler<TTo>
        where TTo : Ffb.Dto.FfbDialog
        where TFrom : Ffb.Dto.FfbDialog
    {
        private readonly DialogHandler<TFrom> Generator;
        public CastedDialogHandler(DialogHandler<TFrom> generator)
            : base(typeof(TFrom))
        {
            Generator = generator;
        }

        public override void Apply(TTo report)
        {
            Generator.Apply(report as TFrom);
        }
    }
}
