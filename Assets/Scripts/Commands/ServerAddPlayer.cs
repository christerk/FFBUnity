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

            Position position = new Position();
            if(t.IsHome && FFB.Instance.Model.PositionsHome[p.positionId] != null)
            {
                position = FFB.Instance.Model.PositionsHome[p.positionId];
            }
            else if(!t.IsHome && FFB.Instance.Model.PositionsAway[p.positionId] != null)
            {
                position = FFB.Instance.Model.PositionsAway[p.positionId];
            }
            Player player = new Player(p, t, position);
            FFB.Instance.Model.AddPlayer(player);
        }
    }
}
