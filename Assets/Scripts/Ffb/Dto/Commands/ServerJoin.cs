namespace Fumbbl.Ffb.Dto.Commands
{
    public class ServerJoin : NetCommand
    {
        public ServerJoin() : base("serverJoin") { }

        public string coach;
        public string clientMode;
        public int spectators;
        public string[] playerNames;
    }
}
