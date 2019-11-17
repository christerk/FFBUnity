using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fumbbl.Dto
{
    public class AbstractCommand
    {
        public string netCommandId { get; }

        public AbstractCommand(string netCommandId)
        {
            this.netCommandId = netCommandId;
        }
    }
}
