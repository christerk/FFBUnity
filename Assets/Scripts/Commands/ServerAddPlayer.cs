using Fumbbl.Ffb.Dto.Reports;
using Fumbbl.Model;
using Fumbbl.Model.Types;

namespace Fumbbl.Commands
{
    public class ServerAddPlayer : CommandHandler<Ffb.Dto.Commands.ServerAddPlayer>
    {
        public override void Apply(Ffb.Dto.Commands.ServerAddPlayer cmd)
        {
            var p = cmd.player;
            Team t = FFB.Instance.Model.GetTeam(cmd.teamId);

            Position position = FFB.Instance.Model.Positions[p.positionId] ?? new Position();
            Player player = Ffb.Conversion.PlayerFactory.Player(p, t, position);
            FFB.Instance.Model.AddPlayer(player);
        }
    }
}
