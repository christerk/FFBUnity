namespace Fumbbl.Model.Types
{
    public class Team
    {
        public Coach Coach { get; internal set; }
        public string Name { get; internal set; }
        public bool IsHome => Coach.IsHome;

        public string Id { get; internal set; }
        public int Fame { get; internal set; }
        public string FormattedName
        {
            get
            {
                string color = IsHome ? "#ff0000" : "#0000ff";
                return $"<{color}>{TextPanelHandler.SanitizeText(Name)}</color>";
            }
        }

        public Team()
        {
            Coach = new Coach();
        }
    }
}
