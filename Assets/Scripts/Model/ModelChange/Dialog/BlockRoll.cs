using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fumbbl.Ffb.Dto.Dialog;

namespace Fumbbl.Model.ModelChange.Dialog
{
    public class BlockRoll : DialogHandler<Ffb.Dto.Dialog.BlockRoll>
    {
        public BlockRoll() : base(typeof(Ffb.Dto.Dialog.BlockRoll)) { }
        public override void Apply(Ffb.Dto.Dialog.BlockRoll dialog)
        {
            if (dialog != null)
            {
                bool home = string.Equals(dialog.choosingTeamId, FFB.Instance.Model.TeamHome.Id);

                IEnumerable<int> rolls = dialog.blockRoll;
                if (!home)
                {
                    rolls = rolls.Reverse();
                }
                foreach (var roll in rolls)
                {
                    FFB.Instance.Model.AddBlockDie(home, roll);
                }
            }
        }
    }
}
