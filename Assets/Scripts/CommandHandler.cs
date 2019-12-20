using Fumbbl.Ffb.Dto;
using System;
using System.Collections.Generic;

namespace Fumbbl
{
    public abstract class CommandHandler<T> : ReflectedGenerator<Type>
        where T : NetCommand
    {
        public CommandHandler() : base(typeof(T)) { }

        public CommandHandler<NetCommand> AsGenericGenerator()
        {
            return this.CastGenerator<T, NetCommand>();
        }

        public void HandleCommand(NetCommand command)
        {
            Apply((T)command);
        }

        public abstract void Apply(T command);
    }

    internal class CastedCommandHandler<TTo, TFrom> : CommandHandler<TTo>
        where TTo : NetCommand
        where TFrom : NetCommand
    {
        private readonly CommandHandler<TFrom> Generator;

        public CastedCommandHandler(CommandHandler<TFrom> generator)
        {
            Generator = generator;
        }

        public override void Apply(TTo report)
        {
            Generator.Apply(report as TFrom);
        }
    }

    public static class CommandHandlerExtensions
    {
        public static CommandHandler<TTo> CastGenerator<TFrom, TTo>(this CommandHandler<TFrom> generator)
            where TTo : NetCommand
            where TFrom : NetCommand
        {
            return new CastedCommandHandler<TTo, TFrom>(generator);
        }
    }
}
