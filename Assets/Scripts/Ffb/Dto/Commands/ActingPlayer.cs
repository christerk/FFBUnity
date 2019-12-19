namespace Fumbbl.Ffb.Dto.Commands
{
    public class ActingPlayer
    {
        public string playerId;
        public int currentMove;
        public bool goingForIt;
        public bool hasBlocked;
        public bool hasFed;
        public bool hasFouled;
        public bool hasMoved;
        public bool hasPassed;
        public FFBEnumeration playerAction;
        public bool standingUp;
        public bool sufferingAnimosity;
        public bool sufferingBloodlust;
        public FFBEnumeration[] usedSkills;
    }
}