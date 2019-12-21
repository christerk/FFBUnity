namespace Fumbbl.Ffb.Dto.Reports
{
    public class CardsBought : Report
    {
        public string reportId;
        public string teamId;
        public int nrOfCards;
        public int gold;

        public CardsBought() : base("cardsBought") { }
    }
}
