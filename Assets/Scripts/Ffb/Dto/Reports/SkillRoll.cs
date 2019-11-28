using System.Collections.Generic;

namespace Fumbbl.Ffb.Dto.Reports
{
    public abstract class SkillRoll : Report
    {
        public SkillRoll(string key) : base(key) { }

        public string reportId;
        public string playerId;
        public bool successful;
        public int roll;
        public int minimumRoll;
        public bool reRolled;

        public List<string> rollModifiers;
    }
}
