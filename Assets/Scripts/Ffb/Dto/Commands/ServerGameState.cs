namespace Fumbbl.Ffb.Dto.Commands
{
    public class ServerGameState : NetCommand
    {
        public ServerGameState() : base("serverGameState") { }

        public int commandNr;
        public Game game;
    }
}
