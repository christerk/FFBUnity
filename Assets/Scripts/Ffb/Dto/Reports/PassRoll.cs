namespace Fumbbl.Ffb.Dto.Reports
{
    public class PassRoll : SkillRoll
    {
        public string passingDistance;
        public bool fumble;
        public bool safeThrowHold;
        public bool hailMaryPass;
        public bool bomb;

        public PassRoll() : base("passRoll") { }
    }
}
