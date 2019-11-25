namespace Fumbbl.Ffb.Dto.Reports
{
    public class PassRoll : SkillRoll
    {
        public PassRoll() : base("passRoll") { }

        public string passingDistance;
        public bool fumble;
        public bool safeThrowHold;
        public bool hailMaryPass;
        public bool bomb;
    }
}
