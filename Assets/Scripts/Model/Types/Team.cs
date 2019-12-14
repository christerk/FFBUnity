namespace Fumbbl.Model.Types
{
    public class Team
    {
        public Coach Coach { get; internal set; }
        public bool IsHome => Coach.IsHome;
        public int Fame { get; internal set; }
        public string Id { get; internal set; }
        public string Name { get; internal set; }

        public string FormattedName
        {
            get
            {
                var colorsettings = FFB.Instance.Settings.Color;
                string color = IsHome ? colorsettings.HomeColor : colorsettings.AwayColor;
                return $"<color={color}>{TextPanelHandler.SanitizeText(Name)}</color>";
            }
        }

        public Team()
        {
            Coach = new Coach();
        }
    }
}
