namespace Fumbbl.Model.Types
{
    public class CardEffect : FfbEnumerationFactory
    {
        public CardEffect(string name) : base(name) { }

        public static CardEffect Distracted = new CardEffect("Distracted") { };
        public static CardEffect IllegallySubstituted = new CardEffect("IllegallySubstituted") { };
        public static CardEffect MadCapMushroomPotion = new CardEffect("MadCapMushroomPotion") { };
        public static CardEffect Sedative = new CardEffect("Sedative") { };
        public static CardEffect Poisoned = new CardEffect("Poisoned") { };
    }
}
