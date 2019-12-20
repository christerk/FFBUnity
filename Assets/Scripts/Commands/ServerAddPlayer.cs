using Fumbbl.Ffb.Dto.Reports;
using Fumbbl.Model;
using Fumbbl.Model.Types;

namespace Fumbbl.Commands
{
    public class AddPlayer : CommandHandler<Ffb.Dto.Commands.AddPlayer>
    {
        public override void Apply(Ffb.Dto.Commands.AddPlayer cmd)
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

            Player player = new Player()
            {
                Id = p.playerId,
                Name = p.playerName,
                Team = t,
                Gender = Gender.Male,
                Movement = p.movement,
                Strength = p.strength,
                Agility = p.agility,
                Armour = p.armour,
                PortraitURL = position.PortraitURL,
                Position = position
            };
            FFB.Instance.Model.AddPlayer(player);
        }
    }
}
