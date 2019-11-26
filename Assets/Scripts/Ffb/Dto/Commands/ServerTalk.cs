namespace Fumbbl.Ffb.Dto.Commands
{
    public class ServerTalk : NetCommand
    {
        public ServerTalk() : base("serverTalk") { }

        public string netCommandId;
        public string coach;
        public string[] talks;
    }
}
