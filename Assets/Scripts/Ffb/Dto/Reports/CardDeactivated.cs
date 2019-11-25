namespace Fumbbl.Ffb.Dto.Reports
{
    public class CardDeactivated : Report
    {
        public CardDeactivated() : base("cardDeactivated") { }

        public string reportId;
        public string card;
    }
}
