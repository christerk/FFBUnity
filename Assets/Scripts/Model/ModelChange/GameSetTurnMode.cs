using Fumbbl.Model.Types;

namespace Fumbbl.Model.ModelChange
{
    public class GameSetTurnMode : ModelUpdater<Ffb.Dto.ModelChanges.GameSetTurnMode>
    {
        public GameSetTurnMode() : base(typeof(Ffb.Dto.ModelChanges.GameSetTurnMode)) { }

        public override void Apply(Ffb.Dto.ModelChanges.GameSetTurnMode change)
        {
            FFB.Instance.Model.TurnMode = change.modelChangeValue.As<TurnMode>();
        }
    }
}
