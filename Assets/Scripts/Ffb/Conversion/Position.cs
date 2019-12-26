
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
                for (int i = 0; i < position.skillArray.Length; i++)
                {
                    var skill = position.skillArray[i].key;
                    newPosition.Skills.Add(skill);
                    var value = position.skillValues[i];
                    newPosition.Skillvalue[skill] = value;
                }
            }

            return newPosition;
        }
    }
}
