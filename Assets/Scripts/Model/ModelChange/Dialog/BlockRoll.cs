using System.Collections.Generic;

namespace Fumbbl.Model.ModelChange.Dialog
{
    public class BlockRoll : DialogHandler<Ffb.Dto.Dialog.BlockRoll>
    {
        public BlockRoll() : base(typeof(Ffb.Dto.Dialog.BlockRoll)) { }

        public override void Apply(Ffb.Dto.Dialog.BlockRoll dialog)
        {
            if (dialog != null)
            {
                IEnumerable<int> rolls = dialog.blockRoll;
                FFB.Instance.Model.AddBlockDie(0);
                foreach (var roll in rolls)
                {
                    FFB.Instance.Model.AddBlockDie(roll);
                }
            }
        }
    }
}
