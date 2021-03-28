
using Fumbbl.Model.Types;
using System.Collections.Generic;
using System.Linq;


namespace Fumbbl.Ffb.Conversion
{
    static class PositionFactory
    {
        public static Position Position(Ffb.Dto.Commands.Position position)
        {
            Position newPosition = new Position()
            {
                Id = position.positionId,
                AbstractLabel = position.shorthand,
                Name = position.positionName,
                IconURL = position.urlIconSet,
                PortraitURL = position.urlPortrait,
            };
            if (position.skillArray != null)
            {
                newPosition.Skills.AddRange(position.skillArray.Select(s => s.key));
            }

            return newPosition;
        }
    }
}