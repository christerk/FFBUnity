
using Fumbbl.Model;


namespace Fumbbl.Ffb.Conversion
{
    static class PositionFactory
    {
        public static Model.Types.Position Position(Ffb.Dto.Commands.Position position)
        {
            Model.Types.Skill skill = null;
            Model.Types.Position newPosition = new Model.Types.Position()
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
                    skill = position.skillArray[i].As<Model.Types.Skill>();
                    newPosition.Skills.Add(skill.Create(value: position.skillValues[i]));
                }
            }

            return newPosition;
        }
    }
}
