namespace Fumbbl.Ffb.Dto.Reports
{
    public class SpecialEffectRoll : Report
    {
        public SpecialEffectRoll() : base("specialEffectRoll") { }
        public string specialEffect;
        public string playerId;
        public int roll;
        public bool successful;
    }
}