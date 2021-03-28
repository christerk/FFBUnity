using System.Collections.Generic;

namespace Fumbbl.Model.Types
{
    public abstract class Skill
    {
        public SkillCategory Category { get; internal set; }
    }

    public class PositionSkill : Skill
    {
        public int? Value { get; internal set; }
    }

    public class PlayerSkill : Skill
    {
    }
}
