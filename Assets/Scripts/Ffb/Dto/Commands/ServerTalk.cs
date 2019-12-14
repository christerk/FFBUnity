namespace Fumbbl.Ffb.Dto.Commands
{
    public class ServerTalk : NetCommand
    {
        public string netCommandId;
        public string coach;
        public string[] talks;

        public ServerTalk() : base("serverTalk") { }
    }
}
