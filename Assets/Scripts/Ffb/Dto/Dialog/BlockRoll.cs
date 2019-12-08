using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fumbbl.Ffb.Dto.Dialog
{
    public class BlockRoll : FfbDialog
    {
        public String choosingTeamId;
        public int nrOfDice;
        public int[] blockRoll;
        public bool teamReRollOption;
        public bool proReRollOption;

        public BlockRoll() : base("blockRoll") { }
    }
}
