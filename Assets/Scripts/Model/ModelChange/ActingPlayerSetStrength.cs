namespace Fumbbl.Model.ModelChange
{
    public class ActingPlayerSetStrength : ModelUpdater<Ffb.Dto.ModelChanges.ActingPlayerSetStrength>
    {
        public ActingPlayerSetStrength() : base(typeof(Ffb.Dto.ModelChanges.ActingPlayerSetStrength)) { }

        public override void Apply(Ffb.Dto.ModelChanges.ActingPlayerSetStrength change)
        {
            FFB.Instance.Model.ActingPlayer.Strength = change.modelChangeValue;
        }
    }
}
