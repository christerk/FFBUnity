using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fumbbl.Ffb.Dto.ModelChanges
{
    public class GameSetDefenderId : ModelChange
    {
        public string modelChangeValue;
        public GameSetDefenderId() : base("gameSetDefenderId") { }
    }
}
