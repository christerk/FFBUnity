namespace Fumbbl.Ffb.Dto.Commands
{
    public class ServerSound : NetCommand
    {
        public string sound;

        public ServerSound() : base("serverSound") { }
    }
}
