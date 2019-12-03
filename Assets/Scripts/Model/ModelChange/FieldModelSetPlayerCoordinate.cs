using Fumbbl.Model.Types;

namespace Fumbbl.Model.ModelChange
{
    public class FieldModelSetPlayerCoordinate : ModelUpdater<Ffb.Dto.ModelChanges.FieldModelSetPlayerCoordinate>
    {
        public FieldModelSetPlayerCoordinate() : base(typeof(Ffb.Dto.ModelChanges.FieldModelSetPlayerCoordinate)) { }

        public override void Apply(Ffb.Dto.ModelChanges.FieldModelSetPlayerCoordinate change)
        {
            Player p = FFB.Instance.Model.GetPlayer(change.modelChangeKey);

            p.Coordinate = new Fumbbl.Model.Types.Coordinate(change.modelChangeValue);
        }
    }
}
