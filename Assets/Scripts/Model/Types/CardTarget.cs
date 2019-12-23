namespace Fumbbl.Model.Types
{
    public class CardTarget : FfbEnumerationFactory
    {
        public CardTarget(string name) : base(name) { }

        public static CardTarget Turn = new CardTarget("turn") { };
        public static CardTarget OwnPlayer = new CardTarget("ownPlayer") { };
        public static CardTarget OpposingPlayer = new CardTarget("opposingPlayer") { };
        public static CardTarget AnyPlayer = new CardTarget("anyPlayer") { };
    }
}
