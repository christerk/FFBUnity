using System.Collections.Generic;

namespace Fumbbl.Model.Types
{
    public class SkillFactory : FfbEnumerationFactory
    {
        public SkillCategory Category;

        public SkillFactory(string name) : base(name) { }

        public static SkillFactory Accurate = new SkillFactory("Accurate") { Category = SkillCategory.Passing };
        public static SkillFactory AlwaysHungry = new SkillFactory("Always Hungry") { Category = SkillCategory.Extraordinary };
        public static SkillFactory Animosity = new SkillFactory("Animosity") { Category = SkillCategory.Extraordinary };
        public static SkillFactory BallAndChain = new SkillFactory("Ball and Chain") { Category = SkillCategory.Extraordinary };
        public static SkillFactory BigHand = new SkillFactory("Big Hand") { Category = SkillCategory.Mutation };
        public static SkillFactory Block = new SkillFactory("Block") { Category = SkillCategory.General };
        public static SkillFactory BloodLust = new SkillFactory("Blood Lust") { Category = SkillCategory.Extraordinary };
        public static SkillFactory Bombardier = new SkillFactory("Bombardier") { Category = SkillCategory.Extraordinary };
        public static SkillFactory BoneHead = new SkillFactory("Bone-Head") { Category = SkillCategory.Extraordinary };
        public static SkillFactory BreakTackle = new SkillFactory("Break Tackle") { Category = SkillCategory.Strength };
        public static SkillFactory Catch = new SkillFactory("Catch") { Category = SkillCategory.Agility };
        public static SkillFactory Chainsaw = new SkillFactory("Chainsaw") { Category = SkillCategory.Extraordinary };
        public static SkillFactory Claw = new SkillFactory("Claw") { Category = SkillCategory.Mutation };
        public static SkillFactory Dauntless = new SkillFactory("Dauntless") { Category = SkillCategory.General };
        public static SkillFactory Decay = new SkillFactory("Decay") { Category = SkillCategory.Extraordinary };
        public static SkillFactory DirtyPlayer = new SkillFactory("Dirty Player") { Category = SkillCategory.General };
        public static SkillFactory DisturbingPresence = new SkillFactory("Disturbing Presence") { Category = SkillCategory.Mutation };
        public static SkillFactory DivingCatch = new SkillFactory("Diving Catch") { Category = SkillCategory.Agility };
        public static SkillFactory DivingTackle = new SkillFactory("Diving Tackle") { Category = SkillCategory.Agility };
        public static SkillFactory Dodge = new SkillFactory("Dodge") { Category = SkillCategory.Agility };
        public static SkillFactory DumpOff = new SkillFactory("Dump-Off") { Category = SkillCategory.Passing };
        public static SkillFactory ExtraArms = new SkillFactory("Extra Arms") { Category = SkillCategory.Mutation };
        public static SkillFactory FanFavourite = new SkillFactory("Fan Favourite") { Category = SkillCategory.Extraordinary };
        public static SkillFactory Fend = new SkillFactory("Fend") { Category = SkillCategory.General };
        public static SkillFactory FoulAppearance = new SkillFactory("Foul Appearance") { Category = SkillCategory.Mutation };
        public static SkillFactory Frenzy = new SkillFactory("Frenzy") { Category = SkillCategory.General };
        public static SkillFactory Grab = new SkillFactory("Grab") { Category = SkillCategory.Strength };
        public static SkillFactory Guard = new SkillFactory("Guard") { Category = SkillCategory.Strength };
        public static SkillFactory HailMaryPass = new SkillFactory("Hail Mary Pass") { Category = SkillCategory.Passing };
        public static SkillFactory Horns = new SkillFactory("Horns") { Category = SkillCategory.Mutation };
        public static SkillFactory HypnoticGaze = new SkillFactory("Hypnotic Gaze") { Category = SkillCategory.Extraordinary };
        public static SkillFactory Juggernaut = new SkillFactory("Juggernaut") { Category = SkillCategory.Strength };
        public static SkillFactory JumpUp = new SkillFactory("Jump Up") { Category = SkillCategory.Agility };
        public static SkillFactory Kick = new SkillFactory("Kick") { Category = SkillCategory.General };
        public static SkillFactory KickOffReturn = new SkillFactory("Kick-Off Return") { Category = SkillCategory.General };
        public static SkillFactory Leader = new SkillFactory("Leader") { Category = SkillCategory.Passing };
        public static SkillFactory Leap = new SkillFactory("Leap") { Category = SkillCategory.Agility };
        public static SkillFactory Loner = new SkillFactory("Loner") { Category = SkillCategory.Extraordinary };
        public static SkillFactory MightyBlow = new SkillFactory("Mighty Blow") { Category = SkillCategory.Strength };
        public static SkillFactory MonstrousMouth = new SkillFactory("Monstrous Mouth") { Category = SkillCategory.Extraordinary };
        public static SkillFactory MultipleBlock = new SkillFactory("Multiple Block") { Category = SkillCategory.Strength };
        public static SkillFactory NervesOfSteel = new SkillFactory("Nerves of Steel") { Category = SkillCategory.Passing };
        public static SkillFactory NoHands = new SkillFactory("No Hands") { Category = SkillCategory.Extraordinary };
        public static SkillFactory NurglesRot = new SkillFactory("Nurgle's Rot") { Category = SkillCategory.Extraordinary };
        public static SkillFactory Pass = new SkillFactory("Pass") { Category = SkillCategory.Passing };
        public static SkillFactory PassBlock = new SkillFactory("Pass Block") { Category = SkillCategory.General };
        public static SkillFactory PilingOn = new SkillFactory("Piling On") { Category = SkillCategory.Strength };
        public static SkillFactory PrehensileTail = new SkillFactory("Prehensile Tail") { Category = SkillCategory.Mutation };
        public static SkillFactory Pro = new SkillFactory("Pro") { Category = SkillCategory.General };
        public static SkillFactory ReallyStupid = new SkillFactory("Really Stupid") { Category = SkillCategory.Extraordinary };
        public static SkillFactory Regeneration = new SkillFactory("Regeneration") { Category = SkillCategory.Extraordinary };
        public static SkillFactory RightStuff = new SkillFactory("Right Stuff") { Category = SkillCategory.Extraordinary };
        public static SkillFactory SafeThrow = new SkillFactory("Safe Throw") { Category = SkillCategory.Passing };
        public static SkillFactory SecretWeapon = new SkillFactory("Secret Weapon") { Category = SkillCategory.Extraordinary };
        public static SkillFactory Shadowing = new SkillFactory("Shadowing") { Category = SkillCategory.General };
        public static SkillFactory SideStep = new SkillFactory("Side Step") { Category = SkillCategory.Agility };
        public static SkillFactory SneakyGit = new SkillFactory("Sneaky Git") { Category = SkillCategory.Agility };
        public static SkillFactory Sprint = new SkillFactory("Sprint") { Category = SkillCategory.Agility };
        public static SkillFactory Stab = new SkillFactory("Stab") { Category = SkillCategory.Extraordinary };
        public static SkillFactory Stakes = new SkillFactory("Stakes") { Category = SkillCategory.Extraordinary };
        public static SkillFactory StandFirm = new SkillFactory("Stand Firm") { Category = SkillCategory.Strength };
        public static SkillFactory StripBall = new SkillFactory("Strip Ball") { Category = SkillCategory.General };
        public static SkillFactory StrongArm = new SkillFactory("Strong Arm") { Category = SkillCategory.Strength };
        public static SkillFactory Stunty = new SkillFactory("Stunty") { Category = SkillCategory.Extraordinary };
        public static SkillFactory SureFeet = new SkillFactory("Sure Feet") { Category = SkillCategory.Agility };
        public static SkillFactory SureHands = new SkillFactory("Sure Hands") { Category = SkillCategory.General };
        public static SkillFactory Swoop = new SkillFactory("Swoop") { Category = SkillCategory.Extraordinary };
        public static SkillFactory Tackle = new SkillFactory("Tackle") { Category = SkillCategory.General };
        public static SkillFactory TakeRoot = new SkillFactory("Take Root") { Category = SkillCategory.Extraordinary };
        public static SkillFactory Tentacles = new SkillFactory("Tentacles") { Category = SkillCategory.Mutation };
        public static SkillFactory ThickSkull = new SkillFactory("Thick Skull") { Category = SkillCategory.Strength };
        public static SkillFactory ThrowTeamMate = new SkillFactory("Throw Team-Mate") { Category = SkillCategory.Extraordinary };
        public static SkillFactory Timmmber = new SkillFactory("Timmm-ber!") { Category = SkillCategory.Extraordinary };
        public static SkillFactory Titchy = new SkillFactory("Titchy") { Category = SkillCategory.Extraordinary };
        public static SkillFactory TwoHeads = new SkillFactory("Two Heads") { Category = SkillCategory.Mutation };
        public static SkillFactory VeryLongLegs = new SkillFactory("Very Long Legs") { Category = SkillCategory.Mutation };
        public static SkillFactory WeepingDagger = new SkillFactory("Weeping Dagger") { Category = SkillCategory.Extraordinary };
        public static SkillFactory WildAnimal = new SkillFactory("Wild Animal") { Category = SkillCategory.Extraordinary };
        public static SkillFactory Wrestle = new SkillFactory("Wrestle") { Category = SkillCategory.General };
        public static SkillFactory PlusMa = new SkillFactory("+MA") { Category = SkillCategory.StatIncrease };
        public static SkillFactory MinusMa = new SkillFactory("-MA") { Category = SkillCategory.StatDecrease };
        public static SkillFactory PlusSt = new SkillFactory("+ST") { Category = SkillCategory.StatIncrease };
        public static SkillFactory MinusSt = new SkillFactory("-ST") { Category = SkillCategory.StatDecrease };
        public static SkillFactory PlusAg = new SkillFactory("+AG") { Category = SkillCategory.StatIncrease };
        public static SkillFactory MinusAg = new SkillFactory("-AG") { Category = SkillCategory.StatDecrease };
        public static SkillFactory PlusAv = new SkillFactory("+AV") { Category = SkillCategory.StatIncrease };
        public static SkillFactory MinusAv = new SkillFactory("-AV") { Category = SkillCategory.StatDecrease };

        public SkillFactory Register(Position position, int? value = null)
        {
            var skill = new PositionSkill() { Category = this.Category, Value = value };
            position.Skills.Add(skill);
        }

        public SkillFactory Register(Player player)
        {
            var skill = new PlayerSkill() { Category = this.Category };
            player.Skills.Add(skill);
        }
    }
}
