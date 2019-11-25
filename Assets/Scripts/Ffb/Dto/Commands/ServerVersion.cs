using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fumbbl.Ffb.Dto.Commands
{
    public class ServerVersion : NetCommand
    {
        public ServerVersion() : base("serverVersion") { }

        public string netCommandId;
        public string commandNr;
        public string serverVersion;
        public string clientVersion;
        public string[] clientPropertyNames;
        public string[] clientPropertyValues;
    }
}
