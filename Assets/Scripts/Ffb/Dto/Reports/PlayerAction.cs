namespace Fumbbl.Ffb.Dto.Reports
{
    public class PlayerAction : Report
    {
        public string reportId;
        public string actingPlayerId;
        public FFBEnumeration playerAction;

        public PlayerAction() : base("playerAction") { }
    }
}
