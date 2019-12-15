namespace Fumbbl.Ffb.Dto.Reports
{
    public class CardDeactivated : Report
    {
        public string reportId;
        public string card;

        public CardDeactivated() : base("cardDeactivated") { }
    }
}
