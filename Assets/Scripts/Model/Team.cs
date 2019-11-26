using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fumbbl.Model
{
    public class Team
    {
        public Coach Coach { get; internal set; }

        public bool IsHome => Coach.IsHome;

        public Team()
        {
            Coach = new Coach();
        }
    }
}
