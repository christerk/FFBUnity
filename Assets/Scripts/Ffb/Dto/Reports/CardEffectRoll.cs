namespace Fumbbl.Ffb.Dto.Reports
{
    public class CardEffectRoll : Report
    {
        public CardEffectRoll() : base("cardEffectRoll") { }

        public string reportId;
        public string card;
        public int roll;
        public string cardEffect;
    }
}
