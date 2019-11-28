namespace Fumbbl.Model.Types
{
    public class Player
    {
        public string Id;
        public string PositionId;
        public string Name;
        public int[] Coordinate;

        public Gender Gender;

        public Team Team { get; set; }

        public bool IsHome => Team.IsHome;

        public Player()
        {
            Team = new Team();
        }

        public string FormattedName
        {
            get
            {
                string color = IsHome ? "#ff0000" : "#0000ff";
                return $"<{color}>{TextPanelHandler.SanitizeText(Name)}</color>";
            }
        }

        public PlayerState PlayerState { get; internal set; }
        public SeriousInjury SeriousInjury { get; internal set; }
        public Position Position { get; internal set; }

        internal bool HasSkill(SkillType skillType)
        {
            return false;
        }
    }
}
