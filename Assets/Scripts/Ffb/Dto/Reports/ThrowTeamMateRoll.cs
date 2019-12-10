namespace Fumbbl.Ffb.Dto.Reports
{
    public class ThrowTeamMateRoll : SkillRoll
    {
        public ThrowTeamMateRoll() : base("throwTeamMateRoll") { }
        public string thrownPlayerId;
        public FFBEnumeration passingDistance;
    }
}