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
                string color = IsHome ? "#ff0000" : "#0000ff";
                return $"<{color}>{TextPanelHandler.SanitizeText(Name)}</color>";
            }
        }
    }
}
