namespace Fumbbl.Model.ModelChange
{
    public class ActingPlayerSetCurrentMove : ModelUpdater<Ffb.Dto.ModelChanges.ActingPlayerSetCurrentMove>
    {
        public ActingPlayerSetCurrentMove() : base(typeof(Ffb.Dto.ModelChanges.ActingPlayerSetCurrentMove)) { }

        public override void Apply(Ffb.Dto.ModelChanges.ActingPlayerSetCurrentMove change)
        {
            FFB.Instance.Model.ActingPlayer.CurrentMove = change.modelChangeValue;
        }
    }
}
