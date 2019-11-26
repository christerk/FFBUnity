namespace Fumbbl.Ffb.Dto.Commands
{
    public class ServerSound : NetCommand
    {
        public ServerSound() : base("serverSound") { }

        public string sound;
    }
}
