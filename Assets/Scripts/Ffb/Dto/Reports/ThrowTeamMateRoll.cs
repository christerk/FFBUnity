namespace Fumbbl.Ffb.Dto.Reports
{
    public class ThrowTeamMateRoll : SkillRoll
    {
        public string thrownPlayerId;
        public FFBEnumeration passingDistance;

        public ThrowTeamMateRoll() : base("throwTeamMateRoll") { }
    }
}
