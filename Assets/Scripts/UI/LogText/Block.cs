using Fumbbl.Dto;
using Fumbbl.Model;

namespace Fumbbl.UI.LogText
{
    public class Block : LogTextGenerator
    {
        public Block() : base(typeof(Dto.Reports.Block)) { }

        public override string Convert(Report report)
        {
            Dto.Reports.Block block = (Dto.Reports.Block)report;
            string attacker = FFB.Instance.Model.GetPlayerName(FFB.Instance.Model.ActingPlayer?.PlayerId);
            string defender = FFB.Instance.Model.GetPlayerName(block.defenderId);

            ActingPlayer.ActionType action = FFB.Instance.Model.ActingPlayer.CurrentAction;

            string actionString = action == ActingPlayer.ActionType.Blitz ? "blitzes" : "blocks";

            return $"{attacker} {actionString} {defender}.";
        }
    }
}
