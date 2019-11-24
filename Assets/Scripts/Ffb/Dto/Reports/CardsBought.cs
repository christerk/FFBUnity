namespace Fumbbl.Ffb.Dto.Reports
{
    public class CardsBought : Report
    {
        public CardsBought() : base("cardBought") { }

        public string reportId;
        public string teamId;
        public int nrOfCards;
        public int gold;
    }
}
