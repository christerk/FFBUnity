namespace Fumbbl.Model.ModelChange
{
    public class ActingPlayerSetPlayerId : ModelUpdater<Ffb.Dto.ModelChanges.ActingPlayerSetPlayerId>
    {
        public ActingPlayerSetPlayerId() : base(typeof(Ffb.Dto.ModelChanges.ActingPlayerSetPlayerId)) { }

        public override void Apply(Ffb.Dto.ModelChanges.ActingPlayerSetPlayerId change)
        {
            FFB.Instance.Model.ActingPlayer.PlayerId = change.modelChangeValue;
            FFB.Instance.Model.ActingPlayer.CurrentMove = 0;
        }
    }
}
