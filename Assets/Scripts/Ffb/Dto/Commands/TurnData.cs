namespace Fumbbl.Ffb.Dto.Commands
{
    public class TurnData
    {
        public bool homeData;
        public bool turnStarted;
        public int turnNr;
        public bool firstTurnAfterKickoff;
        public int reRolls;
        public int apothecaries;
        public bool blitzUsed;
        public bool foulUsed;
        public bool reRollUsed;
        public bool handOverUsed;
        public bool passUsed;
        public bool coachBanned;
        public FFBEnumeration leaderState;
        public InducementSet inducementSet;
    }
}