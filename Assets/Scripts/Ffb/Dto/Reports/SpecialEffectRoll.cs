namespace Fumbbl.Ffb.Dto.Reports
{
    public class SpecialEffectRoll : Report
    {
        public string specialEffect;
        public string playerId;
        public int roll;
        public bool successful;

        public SpecialEffectRoll() : base("specialEffectRoll") { }
    }
}
