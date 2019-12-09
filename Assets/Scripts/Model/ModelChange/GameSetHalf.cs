using Fumbbl.Model.Types;

namespace Fumbbl.Model.ModelChange
{
    public class GameSetHalf : ModelUpdater<Ffb.Dto.ModelChanges.GameSetHalf>
    {
        public GameSetHalf() : base(typeof(Ffb.Dto.ModelChanges.GameSetHalf)) { }

        public override void Apply(Ffb.Dto.ModelChanges.GameSetHalf change)
        {
            FFB.Instance.Model.Half = change.modelChangeValue ?? 0;
        }
    }
}
