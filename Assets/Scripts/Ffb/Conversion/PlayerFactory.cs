
using Fumbbl.Model.Types;
using System.Collections.Generic;
using System.Linq;


namespace Fumbbl.Ffb.Conversion
{
    static class PlayerFactory
    {
        public static Player Player(Ffb.Dto.Commands.Player player, Team team, Position position)
        {
            Player newPlayer = new Player()
            {
                Id = player.playerId,
                Name = player.playerName,
                Team = team,
                Gender = Gender.Male, //TODO: derive this
                PositionId = player.positionId,
                Position = position,
                Movement = player.movement,
                Strength = player.strength,
                Agility = player.agility,
                Armour = player.armour,
                PortraitURL = player.urlPortrait ?? position.PortraitURL
            };

            if (player.skillArray != null)
            {
                newPlayer.Skills.AddRange(player.skillArray.Select(s => s.key));
            }
            return newPlayer;
        }
    }
}