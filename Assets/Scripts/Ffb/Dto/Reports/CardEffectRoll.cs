namespace Fumbbl.Ffb.Dto.Reports
{
    public class CardEffectRoll : Report
    {
        public string reportId;
        public string card;
        public int roll;
        public string cardEffect;

        public CardEffectRoll() : base("cardEffectRoll") { }
    }
}
