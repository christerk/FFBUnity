namespace Fumbbl.Ffb.Dto.Reports
{
    public class CardEffectRoll : Report
    {
        public string reportId;
        public FFBEnumeration card;
        public int roll;
        public FFBEnumeration cardEffect;

        public CardEffectRoll() : base("cardEffectRoll") { }
    }
}
