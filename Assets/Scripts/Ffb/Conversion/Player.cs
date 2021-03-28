
using Fumbbl.Model;


namespace Fumbbl.Ffb.Conversion
{
    static class PlayerFactory
    {
        public static Model.Types.Player Player(Ffb.Dto.Commands.Player player, Model.Types.Team team, Model.Types.Position position)
        {
            Model.Types.Player newPlayer = new Model.Types.Player()
            {
                Id = player.playerId,
                Name = player.playerName,
                Team = team,
                Gender = Model.Types.Gender.Male, //TODO: derive this
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
                for (int i = 0; i < player.skillArray.Length; i++)
                {
                    var skill = player.skillArray[i].As<Model.Types.Skill>();
                    foreach (Model.Types.Skill posskill in newPlayer.Position.Skills)
                    {
                        if (skill.Name == posskill.Name)
                        {
                            skill = posskill;
                            break;
                        }
                    }
                    newPlayer.Skills.Add(skill);
                }
            }
            return newPlayer;
        }
    }
}
