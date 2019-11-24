namespace Fumbbl.Ffb.Dto.Commands
{
    public class ServerGameTime : NetCommand
    {
        public ServerGameTime() : base("serverGameTime") { }

        public long gameTime;
        public long turnTime;
    }
}
