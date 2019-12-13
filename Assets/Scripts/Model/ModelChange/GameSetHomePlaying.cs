using Fumbbl.Model.Types;

namespace Fumbbl.Model.ModelChange
{
    public class GameSetHomePlaying : ModelUpdater<Ffb.Dto.ModelChanges.GameSetHomePlaying>
    {
        public GameSetHomePlaying() : base(typeof(Ffb.Dto.ModelChanges.GameSetHomePlaying)) { }

        public override void Apply(Ffb.Dto.ModelChanges.GameSetHomePlaying change)
        {
            FFB.Instance.Model.HomePlaying = change.modelChangeValue;
        }
    }
}
