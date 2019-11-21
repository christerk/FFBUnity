using Fumbbl.Ffb.Dto;
using Fumbbl.Model;

namespace Fumbbl.UI.LogText
{
    public class Block : LogTextGenerator
    {
        public Block() : base(typeof(Ffb.Dto.Reports.Block)) { }

        public override string Convert(Report report)
        {
            Ffb.Dto.Reports.Block block = (Ffb.Dto.Reports.Block)report;
            string attacker = FFB.Instance.Model.GetPlayer(FFB.Instance.Model.ActingPlayer?.PlayerId).FormattedName;
            string defender = FFB.Instance.Model.GetPlayer(block.defenderId).FormattedName;

            ActingPlayer.ActionType action = FFB.Instance.Model.ActingPlayer.CurrentAction;

            string actionString = action == ActingPlayer.ActionType.Blitz ? "blitzes" : "blocks";

            return $"{attacker} {actionString} {defender}.";
        }
    }
}
