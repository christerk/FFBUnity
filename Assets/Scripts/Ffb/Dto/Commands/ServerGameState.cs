namespace Fumbbl.Ffb.Dto.Commands
{
    public class ServerGameState : NetCommand
    {
        public int commandNr;
        public Game game;

        public ServerGameState() : base("serverGameState") { }
    }
}
