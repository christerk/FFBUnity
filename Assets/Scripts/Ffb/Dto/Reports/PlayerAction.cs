namespace Fumbbl.Dto.Reports
{
    public class PlayerAction : Report
    {
        public PlayerAction() : base("playerAction") { }

        public string reportId;
        public string actingPlayerId;
        public string playerAction;
    }
}
