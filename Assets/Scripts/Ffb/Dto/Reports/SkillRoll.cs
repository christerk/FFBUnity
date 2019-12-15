using System.Collections.Generic;

namespace Fumbbl.Ffb.Dto.Reports
{
    public abstract class SkillRoll : Report
    {
        public string reportId;
        public string playerId;
        public bool successful;
        public int roll;
        public int minimumRoll;
        public bool reRolled;
        public List<FFBEnumeration> rollModifiers;

        public SkillRoll(string key) : base(key) { }
    }
}
