namespace Fumbbl.Model.Types
{
    public class TurnMode : FfbEnumerationFactory
    {
        public bool StoreLast;

        public TurnMode(string name) : base(name) { }

        public static TurnMode Regular = new TurnMode("regular") { StoreLast = true };
        public static TurnMode Setup = new TurnMode("setup") { StoreLast = true };
        public static TurnMode Kickoff = new TurnMode("kickoff") { StoreLast = true };
        public static TurnMode PerfectDefence = new TurnMode("perfectDefence") { StoreLast = true };
        public static TurnMode QuickSnap = new TurnMode("quickSnap") { StoreLast = true };
        public static TurnMode HighKick = new TurnMode("highKick") { StoreLast = true };
        public static TurnMode StartGame = new TurnMode("startGame") { StoreLast = true };
        public static TurnMode Blitz = new TurnMode("blitz") { StoreLast = true };
        public static TurnMode Touchback = new TurnMode("touchback") { StoreLast = true };
        public static TurnMode Interception = new TurnMode("interception") { StoreLast = true };
        public static TurnMode EndGame = new TurnMode("endGame") { StoreLast = true };
        public static TurnMode KickoffReturn = new TurnMode("kickoffReturn") { StoreLast = true };
        public static TurnMode Wizard = new TurnMode("wizard") { StoreLast = true };
        public static TurnMode PassBlock = new TurnMode("passBlock") { StoreLast = true };
        public static TurnMode DumpOff = new TurnMode("dumpOff") { StoreLast = true };
        public static TurnMode NoPlayersToField = new TurnMode("noPlayersToField") { StoreLast = true };
        public static TurnMode BombHome = new TurnMode("bombHome") { StoreLast = false };
        public static TurnMode BombAway = new TurnMode("bombAway") { StoreLast = false };
        public static TurnMode BombHomeBlitz = new TurnMode("bombHomeBlitz") { StoreLast = false };
        public static TurnMode BombAwayBlitz = new TurnMode("bombAwayBlitz") { StoreLast = false };
        public static TurnMode IllegalSubstitution = new TurnMode("illegalSubstitution") { StoreLast = true };
    }
}
