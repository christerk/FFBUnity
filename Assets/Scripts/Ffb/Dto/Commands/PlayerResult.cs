namespace Fumbbl.Ffb.Dto.Commands
{
    public class PlayerResult
    {
        public string playerId;
        public int completions;
        public int touchdowns;
        public int interceptions;
        public int casualties;
        public int playerAwards;
        public int blocks;
        public int fouls;
        public int rushing;
        public int passing;
        public int currentSpps;
        public FFBEnumeration seriousInjury;
        public FFBEnumeration sendToBoxReason;
        public int sendToBoxTurn;
        public int sendToBoxHalf;
        public string sendToBoxPlayerId;
        public bool hasUsedSecretWeapon;
        public bool defecting;
    }
}