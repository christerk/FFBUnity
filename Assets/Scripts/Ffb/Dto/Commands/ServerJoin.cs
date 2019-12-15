namespace Fumbbl.Ffb.Dto.Commands
{
    public class ServerJoin : NetCommand
    {
        public string coach;
        public string clientMode;
        public int spectators;
        public string[] playerNames;

        public ServerJoin() : base("serverJoin") { }
    }
}
