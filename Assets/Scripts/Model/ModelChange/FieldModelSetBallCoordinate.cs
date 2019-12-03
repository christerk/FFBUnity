namespace Fumbbl.Model.ModelChange
{
    public class FieldModelSetBallCoordinate : ModelUpdater<Ffb.Dto.ModelChanges.FieldModelSetBallCoordinate>
    {
        public FieldModelSetBallCoordinate() : base(typeof(Ffb.Dto.ModelChanges.FieldModelSetBallCoordinate)) { }

        public override void Apply(Ffb.Dto.ModelChanges.FieldModelSetBallCoordinate change)
        {
            FFB.Instance.Model.Ball.Coordinate = new Fumbbl.Model.Types.Coordinate(change.modelChangeValue);
        }
    }
}
