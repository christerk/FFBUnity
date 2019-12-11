using System;

namespace Fumbbl.Model.ModelChange
{
    public class GameSetDialogParameter : ModelUpdater<Ffb.Dto.ModelChanges.GameSetDialogParameter>
    {
        private readonly ReflectedFactory<DialogHandler<Ffb.Dto.FfbDialog>, Type> HandlerFactory;

        public GameSetDialogParameter() : base(typeof(Ffb.Dto.ModelChanges.GameSetDialogParameter))
        {
            HandlerFactory = new ReflectedFactory<DialogHandler<Ffb.Dto.FfbDialog>, Type>();
        }

        public override void Apply(Ffb.Dto.ModelChanges.GameSetDialogParameter change)
        {
            if (change != null)
            {
                if (change.modelChangeValue != null)
                {
                    var handler = HandlerFactory.GetReflectedInstance(change.modelChangeValue.GetType());
                    handler.Apply(change.modelChangeValue);
                }
                else
                {
                    // Clear dialogs.
                    FFB.Instance.Model.AddBlockDie(0);
                }
            }
            else
            {

            }
        }
    }
}
