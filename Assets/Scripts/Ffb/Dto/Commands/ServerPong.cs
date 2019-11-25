namespace Fumbbl.Ffb.Dto.Commands
{
    public class ServerPong : NetCommand
    {
        public ServerPong() : base("serverPong") { }

        public long timestamp;
    }
}
