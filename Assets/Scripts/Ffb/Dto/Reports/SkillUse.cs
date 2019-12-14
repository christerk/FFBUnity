namespace Fumbbl.Ffb.Dto.Reports
{
    public class SkillUse : Report
    {
        public string reportId;
        public string playerId;
        public string skill;
        public bool used;
        public string skillUse;

        public SkillUse() : base("skillUse") { }
    }
}
