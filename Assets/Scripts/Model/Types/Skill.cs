using System.Collections.Generic;

namespace Fumbbl.Model.Types
{
    public class Skill : FfbEnumerationFactory
    {
        public SkillCategory Category;

        public Skill(string name) : base(name) { }

        public static Skill Accurate = new Skill("Accurate") { Category = SkillCategory.Passing };
        public static Skill AlwaysHungry = new Skill("Always Hungry") { Category = SkillCategory.Extraordinary };
        public static Skill Animosity = new Skill("Animosity") { Category = SkillCategory.Extraordinary };
        public static Skill BallAndChain = new Skill("Ball and Chain") { Category = SkillCategory.Extraordinary };
        public static Skill BigHand = new Skill("Big Hand") { Category = SkillCategory.Mutation };
        public static Skill Block = new Skill("Block") { Category = SkillCategory.General };
        public static Skill BloodLust = new Skill("Blood Lust") { Category = SkillCategory.Extraordinary };
        public static Skill Bombardier = new Skill("Bombardier") { Category = SkillCategory.Extraordinary };
        public static Skill BoneHead = new Skill("Bone-Head") { Category = SkillCategory.Extraordinary };
        public static Skill BreakTackle = new Skill("Break Tackle") { Category = SkillCategory.Strength };
        public static Skill Catch = new Skill("Catch") { Category = SkillCategory.Agility };
        public static Skill Chainsaw = new Skill("Chainsaw") { Category = SkillCategory.Extraordinary };
        public static Skill Claw = new Skill("Claw") { Category = SkillCategory.Mutation };
        public static Skill Dauntless = new Skill("Dauntless") { Category = SkillCategory.General };
        public static Skill Decay = new Skill("Decay") { Category = SkillCategory.Extraordinary };
        public static Skill DirtyPlayer = new Skill("Dirty Player") { Category = SkillCategory.General };
        public static Skill DisturbingPresence = new Skill("Disturbing Presence") { Category = SkillCategory.Mutation };
        public static Skill DivingCatch = new Skill("Diving Catch") { Category = SkillCategory.Agility };
        public static Skill DivingTackle = new Skill("Diving Tackle") { Category = SkillCategory.Agility };
        public static Skill Dodge = new Skill("Dodge") { Category = SkillCategory.Agility };
        public static Skill DumpOff = new Skill("Dump-Off") { Category = SkillCategory.Passing };
        public static Skill ExtraArms = new Skill("Extra Arms") { Category = SkillCategory.Mutation };
        public static Skill FanFavourite = new Skill("Fan Favourite") { Category = SkillCategory.Extraordinary };
        public static Skill Fend = new Skill("Fend") { Category = SkillCategory.General };
        public static Skill FoulAppearance = new Skill("Foul Appearance") { Category = SkillCategory.Mutation };
        public static Skill Frenzy = new Skill("Frenzy") { Category = SkillCategory.General };
        public static Skill Grab = new Skill("Grab") { Category = SkillCategory.Strength };
        public static Skill Guard = new Skill("Guard") { Category = SkillCategory.Strength };
        public static Skill HailMaryPass = new Skill("Hail Mary Pass") { Category = SkillCategory.Passing };
        public static Skill Horns = new Skill("Horns") { Category = SkillCategory.Mutation };
        public static Skill HypnoticGaze = new Skill("Hypnotic Gaze") { Category = SkillCategory.Extraordinary };
        public static Skill Juggernaut = new Skill("Juggernaut") { Category = SkillCategory.Strength };
        public static Skill JumpUp = new Skill("Jump Up") { Category = SkillCategory.Agility };
        public static Skill Kick = new Skill("Kick") { Category = SkillCategory.General };
        public static Skill KickOffReturn = new Skill("Kick-Off Return") { Category = SkillCategory.General };
        public static Skill Leader = new Skill("Leader") { Category = SkillCategory.Passing };
        public static Skill Leap = new Skill("Leap") { Category = SkillCategory.Agility };
        public static Skill Loner = new Skill("Loner") { Category = SkillCategory.Extraordinary };
        public static Skill MightyBlow = new Skill("Mighty Blow") { Category = SkillCategory.Strength };
        public static Skill MonstrousMouth = new Skill("Monstrous Mouth") { Category = SkillCategory.Extraordinary };
        public static Skill MultipleBlock = new Skill("Multiple Block") { Category = SkillCategory.Strength };
        public static Skill NervesOfSteel = new Skill("Nerves of Steel") { Category = SkillCategory.Passing };
        public static Skill NoHands = new Skill("No Hands") { Category = SkillCategory.Extraordinary };
        public static Skill NurglesRot = new Skill("Nurgle's Rot") { Category = SkillCategory.Extraordinary };
        public static Skill Pass = new Skill("Pass") { Category = SkillCategory.Passing };
        public static Skill PassBlock = new Skill("Pass Block") { Category = SkillCategory.General };
        public static Skill PilingOn = new Skill("Piling On") { Category = SkillCategory.Strength };
        public static Skill PrehensileTail = new Skill("Prehensile Tail") { Category = SkillCategory.Mutation };
        public static Skill Pro = new Skill("Pro") { Category = SkillCategory.General };
        public static Skill ReallyStupid = new Skill("Really Stupid") { Category = SkillCategory.Extraordinary };
        public static Skill Regeneration = new Skill("Regeneration") { Category = SkillCategory.Extraordinary };
        public static Skill RightStuff = new Skill("Right Stuff") { Category = SkillCategory.Extraordinary };
        public static Skill SafeThrow = new Skill("Safe Throw") { Category = SkillCategory.Passing };
        public static Skill SecretWeapon = new Skill("Secret Weapon") { Category = SkillCategory.Extraordinary };
        public static Skill Shadowing = new Skill("Shadowing") { Category = SkillCategory.General };
        public static Skill SideStep = new Skill("Side Step") { Category = SkillCategory.Agility };
        public static Skill SneakyGit = new Skill("Sneaky Git") { Category = SkillCategory.Agility };
        public static Skill Sprint = new Skill("Sprint") { Category = SkillCategory.Agility };
        public static Skill Stab = new Skill("Stab") { Category = SkillCategory.Extraordinary };
        public static Skill Stakes = new Skill("Stakes") { Category = SkillCategory.Extraordinary };
        public static Skill StandFirm = new Skill("Stand Firm") { Category = SkillCategory.Strength };
        public static Skill StripBall = new Skill("Strip Ball") { Category = SkillCategory.General };
        public static Skill StrongArm = new Skill("Strong Arm") { Category = SkillCategory.Strength };
        public static Skill Stunty = new Skill("Stunty") { Category = SkillCategory.Extraordinary };
        public static Skill SureFeet = new Skill("Sure Feet") { Category = SkillCategory.Agility };
        public static Skill SureHands = new Skill("Sure Hands") { Category = SkillCategory.General };
        public static Skill Swoop = new Skill("Swoop") { Category = SkillCategory.Extraordinary };
        public static Skill Tackle = new Skill("Tackle") { Category = SkillCategory.General };
        public static Skill TakeRoot = new Skill("Take Root") { Category = SkillCategory.Extraordinary };
        public static Skill Tentacles = new Skill("Tentacles") { Category = SkillCategory.Mutation };
        public static Skill ThickSkull = new Skill("Thick Skull") { Category = SkillCategory.Strength };
        public static Skill ThrowTeamMate = new Skill("Throw Team-Mate") { Category = SkillCategory.Extraordinary };
        public static Skill Timmmber = new Skill("Timmm-ber!") { Category = SkillCategory.Extraordinary };
        public static Skill Titchy = new Skill("Titchy") { Category = SkillCategory.Extraordinary };
        public static Skill TwoHeads = new Skill("Two Heads") { Category = SkillCategory.Mutation };
        public static Skill VeryLongLegs = new Skill("Very Long Legs") { Category = SkillCategory.Mutation };
        public static Skill WeepingDagger = new Skill("Weeping Dagger") { Category = SkillCategory.Extraordinary };
        public static Skill WildAnimal = new Skill("Wild Animal") { Category = SkillCategory.Extraordinary };
        public static Skill Wrestle = new Skill("Wrestle") { Category = SkillCategory.General };
        public static Skill PlusMa = new Skill("+MA") { Category = SkillCategory.StatIncrease };
        public static Skill MinusMa = new Skill("-MA") { Category = SkillCategory.StatDecrease };
        public static Skill PlusSt = new Skill("+ST") { Category = SkillCategory.StatIncrease };
        public static Skill MinusSt = new Skill("-ST") { Category = SkillCategory.StatDecrease };
        public static Skill PlusAg = new Skill("+AG") { Category = SkillCategory.StatIncrease };
        public static Skill MinusAg = new Skill("-AG") { Category = SkillCategory.StatDecrease };
        public static Skill PlusAv = new Skill("+AV") { Category = SkillCategory.StatIncrease };
        public static Skill MinusAv = new Skill("-AV") { Category = SkillCategory.StatDecrease };
    }
}
