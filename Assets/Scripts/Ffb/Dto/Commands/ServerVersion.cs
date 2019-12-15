namespace Fumbbl.Ffb.Dto.Commands
{
    public class ServerVersion : NetCommand
    {
        public string netCommandId;
        public string commandNr;
        public string serverVersion;
        public string clientVersion;
        public string[] clientPropertyNames;
        public string[] clientPropertyValues;

        public ServerVersion() : base("serverVersion") { }
    }
}
