namespace Fumbbl.Ffb.Dto.Commands
{
    public class ServerAddPlayer : NetCommand
    {
        public string teamId;
        public Player player;
        public string sendToBoxReason;
        public int sendToBoxTurn;
        public int sendToBoxHalf;

        public ServerAddPlayer() : base("serverAddPlayer") { }
    }
}
