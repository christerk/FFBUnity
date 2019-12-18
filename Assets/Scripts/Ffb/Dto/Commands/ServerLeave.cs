namespace Fumbbl.Ffb.Dto.Commands
{
    public class ServerLeave : NetCommand
    {
        public string coach;
        public string clientMode;
        public int spectators;

        public ServerLeave() : base("serverLeave") { }
    }
}
