using System.Collections.Generic;

namespace Fumbbl.Model.Types
{
    public class Position
    {
        public string Id { get; set; }
        public string AbstractLabel { get; set; }
        public string IconURL { get; set; }
        public string PortraitURL { get; set; }
        public string Name { get; internal set; }
        public List<PositionSkill> Skills { get; set; }

        public Position()
        {
            Skills = new List<PositionSkill>();
        }
    }
}
