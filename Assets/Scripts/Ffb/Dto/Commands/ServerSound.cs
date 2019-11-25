using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fumbbl.Ffb.Dto.Commands
{
    public class ServerSound : NetCommand
    {
        public ServerSound() : base("serverSound") { }

        public string sound;
    }
}
