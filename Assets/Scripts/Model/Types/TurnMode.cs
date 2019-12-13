namespace Fumbbl.Model.Types
{
    public class TurnMode : FfbEnumerationFactory
    {
        public TurnMode(string name) : base(name) { }

        public static TurnMode Regular = new TurnMode("regular");
        public static TurnMode Setup = new TurnMode("setup");
        public static TurnMode Kickoff = new TurnMode("kickoff");
        public static TurnMode PerfectDefence = new TurnMode("perfectDefence");
        public static TurnMode QuickSnap = new TurnMode("quickSnap");
        public static TurnMode HighKick = new TurnMode("highKick");
        public static TurnMode StartGame = new TurnMode("startGame");
        public static TurnMode Blitz = new TurnMode("blitz");
        public static TurnMode Touchback = new TurnMode("touchback");
        public static TurnMode Interception = new TurnMode("interception");
        public static TurnMode EndGame = new TurnMode("endGame");
        public static TurnMode KickoffReturn = new TurnMode("kickoffReturn");
        public static TurnMode Wizard = new TurnMode("wizard");
        public static TurnMode PassBlock = new TurnMode("passBlock");
        public static TurnMode DumpOff = new TurnMode("dumpOff");
        public static TurnMode NoPlayersToField = new TurnMode("noPlayersToField");
        public static TurnMode BombHome = new TurnMode("bombHome");
        public static TurnMode BombAway = new TurnMode("bombAway");
        public static TurnMode BombHomeBlitz = new TurnMode("bombHomeBlitz");
        public static TurnMode BombAwayBlitz = new TurnMode("bombAwayBlitz");
        public static TurnMode IllegalSubstitution = new TurnMode("illegalSubstitution");
    }
}
