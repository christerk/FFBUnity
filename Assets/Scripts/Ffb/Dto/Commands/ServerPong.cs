namespace Fumbbl.Ffb.Dto.Commands
{
    public class ServerPong : NetCommand
    {
        public long timestamp;

        public ServerPong() : base("serverPong") { }
    }
}
