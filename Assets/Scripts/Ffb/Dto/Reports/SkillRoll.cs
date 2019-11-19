using System.Collections.Generic;

namespace Fumbbl.Dto.Reports
{
    public abstract class SkillRoll : IReport
    {
        public string reportId;
        public string playerId;
        public bool successful;
        public int roll;
        public int minimumRoll;
        public bool reRolled;

        public List<string> rollModifiers;
    }
}
