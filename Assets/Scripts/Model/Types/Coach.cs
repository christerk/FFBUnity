namespace Fumbbl.Model.Types
{
    public class Coach
    {
        public bool IsHome { get; set; }

        public string Name { get; set; }

        public string FormattedName
        {
            get
            {
                var colorsettings = FFB.Instance.Settings.Color;
                string color = IsHome ? colorsettings.HomeColor : colorsettings.AwayColor;
                return $"<color={color}>{TextPanelHandler.SanitizeText(Name)}</color>";
            }
        }
    }
}
