using Fumbbl.Model.Types;

namespace Fumbbl.Model.ModelChange
{
    public class GameSetPassCoordinate : ModelUpdater<Ffb.Dto.ModelChanges.GameSetPassCoordinate>
    {
        public GameSetPassCoordinate() : base(typeof(Ffb.Dto.ModelChanges.GameSetPassCoordinate)) { }

        public override void Apply(Ffb.Dto.ModelChanges.GameSetPassCoordinate change)
        {
            FFB.Instance.Model.PassCoordinate = Coordinate.Create(change.modelChangeValue);
        }
    }
}
