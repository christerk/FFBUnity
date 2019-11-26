namespace Fumbbl.Ffb.Dto.Reports
{
    public class PlayerAction : Report
    {
        public PlayerAction() : base("playerAction") { }

        public string reportId;
        public string actingPlayerId;
        public FFBEnumeration playerAction;
    }
}
