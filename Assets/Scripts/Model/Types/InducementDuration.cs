namespace Fumbbl.Model.Types
{
    public class InducementDuration : FfbEnumerationFactory
    {
        public string Description;

        public InducementDuration(string name) : base(name) { }

        public static InducementDuration UntilEndOfGame = new InducementDuration("untilEndOfGame") { Description = "For the entire game" };
        public static InducementDuration UntilEndOfDrive = new InducementDuration("untilEndOfDrive") { Description = "For this drive" };
        public static InducementDuration UntilEndOfTurn = new InducementDuration("untilEndOfTurn") { Description = "For this turn" };
        public static InducementDuration WhileHoldingTheBall = new InducementDuration("whileHoldingTheBall") { Description = "While holding the ball" };
        public static InducementDuration UntilUsed = new InducementDuration("untilUsed") { Description = "Single use" };
        public static InducementDuration UntilEndOfOpponentsTurn = new InducementDuration("untilEndOfOpponentsTurn") { Description = "For opponent's turn" };
    }
}
