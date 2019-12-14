namespace Fumbbl.Ffb.Dto.Reports
{
    public class PassRoll : SkillRoll
    {
        public FFBEnumeration passingDistance;
        public bool bomb;
        public bool fumble;
        public bool hailMaryPass;
        public bool safeThrowHold;

        public PassRoll() : base("passRoll") { }
    }
}
