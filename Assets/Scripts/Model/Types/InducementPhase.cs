namespace Fumbbl.Model.Types
{
    public class InducementPhase : FfbEnumerationFactory
    {
        public string Description;

        public InducementPhase(string name) : base(name) { }

        public static InducementPhase EndOfOwnTurn = new InducementPhase("endOfOwnTurn") { Description = "at end of own turn" };
        public static InducementPhase StartOfOwnTurn = new InducementPhase("startOfOwnTurn") { Description = "at start of own turn" };
        public static InducementPhase AfterKickoffToOpponent = new InducementPhase("afterKickoffToOpponent") { Description = "after Kickoff to opponent" };
        public static InducementPhase AfterInducementsPurchased = new InducementPhase("afterInducementsPurchased") { Description = "after Inducements are purchased" };
        public static InducementPhase BeforeKickoffScatter = new InducementPhase("beforeKickoffScatter") { Description = "before Kickoff Scatter" };
        public static InducementPhase EndOfTurnNotHalf = new InducementPhase("endOfTurnNotHalf") { Description = "at end of turn, not half" };
        public static InducementPhase BeforeSetup = new InducementPhase("beforeSetup") { Description = "before setting up" };
    }
}
