namespace Fumbbl.Ffb.Dto.Commands
{
    public class ServerGameTime : NetCommand
    {
        public long gameTime;
        public long turnTime;

        public ServerGameTime() : base("serverGameTime") { }
    }
}
