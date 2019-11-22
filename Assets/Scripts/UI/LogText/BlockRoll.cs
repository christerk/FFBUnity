using Assets.Scripts.Model;
using Fumbbl.Ffb.Dto;
using Fumbbl.Model;
using System.Linq;

namespace Fumbbl.UI.LogText
{
    public class BlockRoll : LogTextGenerator
    {
        public BlockRoll() : base(typeof(Fumbbl.Ffb.Dto.Reports.BlockRoll)) { }

        public override string Convert(Report report)
        {
            Ffb.Dto.Reports.BlockRoll blockRoll = (Ffb.Dto.Reports.BlockRoll)report;

            return $"Block Roll [ { string.Join(" ] [ ", blockRoll.blockRoll.Select(r => Util.GetBlockDie(r).GetName())) } ]";
        }
    }
}
