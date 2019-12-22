namespace Fumbbl.Ffb.Dto.Reports
{
    public class CardDeactivated : Report
    {
        public string reportId;
        public FFBEnumeration card;

        public CardDeactivated() : base("cardDeactivated") { }
    }
}
