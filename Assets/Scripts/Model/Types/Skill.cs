using System.Collections.Generic;

namespace Fumbbl.Model.Types
{
    public class Skill
    {
        public string Name { get; set; }
        public SkillCategory Category { get; set; }

        public static Skill Accurate = new Skill() { Name = "Accurate", Category = SkillCategory.Passing };
        public static Skill AlwaysHungry = new Skill() { Name = "Always Hungry", Category = SkillCategory.Extraordinary };
        public static Skill Animosity = new Skill() { Name = "Animosity", Category = SkillCategory.Extraordinary };
        public static Skill BallAndChain = new Skill() { Name = "Ball and Chain", Category = SkillCategory.Extraordinary };
        public static Skill BigHand = new Skill() { Name = "Big Hand", Category = SkillCategory.Mutation };
        public static Skill Block = new Skill() { Name = "Block", Category = SkillCategory.General };
        public static Skill BloodLust = new Skill() { Name = "Blood Lust", Category = SkillCategory.Extraordinary };
        public static Skill Bombardier = new Skill() { Name = "Bombardier", Category = SkillCategory.Extraordinary };
        public static Skill BoneHead = new Skill() { Name = "Bone-Head", Category = SkillCategory.Extraordinary };
        public static Skill BreakTackle = new Skill() { Name = "Break Tackle", Category = SkillCategory.Strength };
        public static Skill Catch = new Skill() { Name = "Catch", Category = SkillCategory.Agility };
        public static Skill Chainsaw = new Skill() { Name = "Chainsaw", Category = SkillCategory.Extraordinary };
        public static Skill Claw = new Skill() { Name = "Claw", Category = SkillCategory.Mutation };
        public static Skill Dauntless = new Skill() { Name = "Dauntless", Category = SkillCategory.General };
        public static Skill Decay = new Skill() { Name = "Decay", Category = SkillCategory.Extraordinary };
        public static Skill DirtyPlayer = new Skill() { Name = "Dirty Player", Category = SkillCategory.General };
        public static Skill DisturbingPresence = new Skill() { Name = "Disturbing Presence", Category = SkillCategory.Mutation };
        public static Skill DivingCatch = new Skill() { Name = "Diving Catch", Category = SkillCategory.Agility };
        public static Skill DivingTackle = new Skill() { Name = "Diving Tackle", Category = SkillCategory.Agility };
        public static Skill Dodge = new Skill() { Name = "Dodge", Category = SkillCategory.Agility };
        public static Skill DumpOff = new Skill() { Name = "Dump-Off", Category = SkillCategory.Passing };
        public static Skill ExtraArms = new Skill() { Name = "Extra Arms", Category = SkillCategory.Mutation };
        public static Skill FanFavourite = new Skill() { Name = "Fan Favourite", Category = SkillCategory.Extraordinary };
        public static Skill Fend = new Skill() { Name = "Fend", Category = SkillCategory.General };
        public static Skill FoulAppearance = new Skill() { Name = "Foul Appearance", Category = SkillCategory.Mutation };
        public static Skill Frenzy = new Skill() { Name = "Frenzy", Category = SkillCategory.General };
        public static Skill Grab = new Skill() { Name = "Grab", Category = SkillCategory.Strength };
        public static Skill Guard = new Skill() { Name = "Guard", Category = SkillCategory.Strength };
        public static Skill HailMaryPass = new Skill() { Name = "Hail Mary Pass", Category = SkillCategory.Passing };
        public static Skill Horns = new Skill() { Name = "Horns", Category = SkillCategory.Mutation };
        public static Skill HypnoticGaze = new Skill() { Name = "Hypnotic Gaze", Category = SkillCategory.Extraordinary };
        public static Skill Juggernaut = new Skill() { Name = "Juggernaut", Category = SkillCategory.Strength };
        public static Skill JumpUp = new Skill() { Name = "Jump Up", Category = SkillCategory.Agility };
        public static Skill Kick = new Skill() { Name = "Kick", Category = SkillCategory.General };
        public static Skill KickOffReturn = new Skill() { Name = "Kick-Off Return", Category = SkillCategory.General };
        public static Skill Leader = new Skill() { Name = "Leader", Category = SkillCategory.Passing };
        public static Skill Leap = new Skill() { Name = "Leap", Category = SkillCategory.Agility };
        public static Skill Loner = new Skill() { Name = "Loner", Category = SkillCategory.Extraordinary };
        public static Skill MightyBlow = new Skill() { Name = "Mighty Blow", Category = SkillCategory.Strength };
        public static Skill MonstrousMouth = new Skill() { Name = "Monstrous Mouth", Category = SkillCategory.Extraordinary };
        public static Skill MultipleBlock = new Skill() { Name = "Multiple Block", Category = SkillCategory.Strength };
        public static Skill NervesOfSteel = new Skill() { Name = "Nerves of Steel", Category = SkillCategory.Passing };
        public static Skill NoHands = new Skill() { Name = "No Hands", Category = SkillCategory.Extraordinary };
        public static Skill NurglesRot = new Skill() { Name = "Nurgle's Rot", Category = SkillCategory.Extraordinary };
        public static Skill Pass = new Skill() { Name = "Pass", Category = SkillCategory.Passing };
        public static Skill PassBlock = new Skill() { Name = "Pass Block", Category = SkillCategory.General };
        public static Skill PilingOn = new Skill() { Name = "Piling On", Category = SkillCategory.Strength };
        public static Skill PrehensileTail = new Skill() { Name = "Prehensile Tail", Category = SkillCategory.Mutation };
        public static Skill Pro = new Skill() { Name = "Pro", Category = SkillCategory.General };
        public static Skill ReallyStupid = new Skill() { Name = "Really Stupid", Category = SkillCategory.Extraordinary };
        public static Skill Regeneration = new Skill() { Name = "Regeneration", Category = SkillCategory.Extraordinary };
        public static Skill RightStuff = new Skill() { Name = "Right Stuff", Category = SkillCategory.Extraordinary };
        public static Skill SafeThrow = new Skill() { Name = "Safe Throw", Category = SkillCategory.Passing };
        public static Skill SecretWeapon = new Skill() { Name = "Secret Weapon", Category = SkillCategory.Extraordinary };
        public static Skill Shadowing = new Skill() { Name = "Shadowing", Category = SkillCategory.General };
        public static Skill SideStep = new Skill() { Name = "Side Step", Category = SkillCategory.Agility };
        public static Skill SneakyGit = new Skill() { Name = "Sneaky Git", Category = SkillCategory.Agility };
        public static Skill Sprint = new Skill() { Name = "Sprint", Category = SkillCategory.Agility };
        public static Skill Stab = new Skill() { Name = "Stab", Category = SkillCategory.Extraordinary };
        public static Skill Stakes = new Skill() { Name = "Stakes", Category = SkillCategory.Extraordinary };
        public static Skill StandFirm = new Skill() { Name = "Stand Firm", Category = SkillCategory.Strength };
        public static Skill StripBall = new Skill() { Name = "Strip Ball", Category = SkillCategory.General };
        public static Skill StrongArm = new Skill() { Name = "Strong Arm", Category = SkillCategory.Strength };
        public static Skill Stunty = new Skill() { Name = "Stunty", Category = SkillCategory.Extraordinary };
        public static Skill SureFeet = new Skill() { Name = "Sure Feet", Category = SkillCategory.Agility };
        public static Skill SureHands = new Skill() { Name = "Sure Hands", Category = SkillCategory.General };
        public static Skill Swoop = new Skill() { Name = "Swoop", Category = SkillCategory.Extraordinary };
        public static Skill Tackle = new Skill() { Name = "Tackle", Category = SkillCategory.General };
        public static Skill TakeRoot = new Skill() { Name = "Take Root", Category = SkillCategory.Extraordinary };
        public static Skill Tentacles = new Skill() { Name = "Tentacles", Category = SkillCategory.Mutation };
        public static Skill ThickSkull = new Skill() { Name = "Thick Skull", Category = SkillCategory.Strength };
        public static Skill ThrowTeamMate = new Skill() { Name = "Throw Team-Mate", Category = SkillCategory.Extraordinary };
        public static Skill Timmmber = new Skill() { Name = "Timmm-ber!", Category = SkillCategory.Extraordinary };
        public static Skill Titchy = new Skill() { Name = "Titchy", Category = SkillCategory.Extraordinary };
        public static Skill TwoHeads = new Skill() { Name = "Two Heads", Category = SkillCategory.Mutation };
        public static Skill VeryLongLegs = new Skill() { Name = "Very Long Legs", Category = SkillCategory.Mutation };
        public static Skill WeepingDagger = new Skill() { Name = "Weeping Dagger", Category = SkillCategory.Extraordinary };
        public static Skill WildAnimal = new Skill() { Name = "Wild Animal", Category = SkillCategory.Extraordinary };
        public static Skill Wrestle = new Skill() { Name = "Wrestle", Category = SkillCategory.General };
        public static Skill PlusMa = new Skill() { Name = "+MA", Category = SkillCategory.StatIncrease };
        public static Skill MinusMa = new Skill() { Name = "-MA", Category = SkillCategory.StatDecrease };
        public static Skill PlusSt = new Skill() { Name = "+ST", Category = SkillCategory.StatIncrease };
        public static Skill MinusSt = new Skill() { Name = "-ST", Category = SkillCategory.StatDecrease };
        public static Skill PlusAg = new Skill() { Name = "+AG", Category = SkillCategory.StatIncrease };
        public static Skill MinusAg = new Skill() { Name = "-AG", Category = SkillCategory.StatDecrease };
        public static Skill PlusAv = new Skill() { Name = "+AV", Category = SkillCategory.StatIncrease };
        public static Skill MinusAv = new Skill() { Name = "-AV", Category = SkillCategory.StatDecrease };

    }

    public static class SkillExtensions
    {
        private static readonly Dictionary<string, Skill> Skills = new Dictionary<string, Skill>();

        static SkillExtensions()
        {
            Skills = new Dictionary<string, Skill>()
            {
                ["Accurate"] = Skill.Accurate,
                ["Always Hungry"] = Skill.AlwaysHungry,
                ["Animosity"] = Skill.Animosity,
                ["Ball and Chain"] = Skill.BallAndChain,
                ["Big Hand"] = Skill.BigHand,
                ["Block"] = Skill.Block,
                ["Blood Lust"] = Skill.BloodLust,
                ["Bombardier"] = Skill.Bombardier,
                ["Bone-Head"] = Skill.BoneHead,
                ["Break Tackle"] = Skill.BreakTackle,
                ["Catch"] = Skill.Catch,
                ["Chainsaw"] = Skill.Chainsaw,
                ["Claw"] = Skill.Claw,
                ["Dauntless"] = Skill.Dauntless,
                ["Decay"] = Skill.Decay,
                ["Dirty Player"] = Skill.DirtyPlayer,
                ["Disturbing Presence"] = Skill.DisturbingPresence,
                ["Diving Catch"] = Skill.DivingCatch,
                ["Diving Tackle"] = Skill.DivingTackle,
                ["Dodge"] = Skill.Dodge,
                ["Dump-Off"] = Skill.DumpOff,
                ["Extra Arms"] = Skill.ExtraArms,
                ["Fan Favourite"] = Skill.FanFavourite,
                ["Fend"] = Skill.Fend,
                ["Foul Appearance"] = Skill.FoulAppearance,
                ["Frenzy"] = Skill.Frenzy,
                ["Grab"] = Skill.Grab,
                ["Guard"] = Skill.Guard,
                ["Hail Mary Pass"] = Skill.HailMaryPass,
                ["Horns"] = Skill.Horns,
                ["Hypnotic Gaze"] = Skill.HypnoticGaze,
                ["Juggernaut"] = Skill.Juggernaut,
                ["Jump Up"] = Skill.JumpUp,
                ["Kick"] = Skill.Kick,
                ["Kick-Off Return"] = Skill.KickOffReturn,
                ["Leader"] = Skill.Leader,
                ["Leap"] = Skill.Leap,
                ["Loner"] = Skill.Loner,
                ["Mighty Blow"] = Skill.MightyBlow,
                ["Monstrous Mouth"] = Skill.MonstrousMouth,
                ["Multiple Block"] = Skill.MultipleBlock,
                ["Nerves of Steel"] = Skill.NervesOfSteel,
                ["No Hands"] = Skill.NoHands,
                ["Nurgle's Rot"] = Skill.NurglesRot,
                ["Pass"] = Skill.Pass,
                ["Pass Block"] = Skill.PassBlock,
                ["Piling On"] = Skill.PilingOn,
                ["Prehensile Tail"] = Skill.PrehensileTail,
                ["Pro"] = Skill.Pro,
                ["Really Stupid"] = Skill.ReallyStupid,
                ["Regeneration"] = Skill.Regeneration,
                ["Right Stuff"] = Skill.RightStuff,
                ["Safe Throw"] = Skill.SafeThrow,
                ["Secret Weapon"] = Skill.SecretWeapon,
                ["Shadowing"] = Skill.Shadowing,
                ["Side Step"] = Skill.SideStep,
                ["Sneaky Git"] = Skill.SneakyGit,
                ["Sprint"] = Skill.Sprint,
                ["Stab"] = Skill.Stab,
                ["Stakes"] = Skill.Stakes,
                ["Stand Firm"] = Skill.StandFirm,
                ["Strip Ball"] = Skill.StripBall,
                ["Strong Arm"] = Skill.StrongArm,
                ["Stunty"] = Skill.Stunty,
                ["Sure Feet"] = Skill.SureFeet,
                ["Sure Hands"] = Skill.SureHands,
                ["Swoop"] = Skill.Swoop,
                ["Tackle"] = Skill.Tackle,
                ["Take Root"] = Skill.TakeRoot,
                ["Tentacles"] = Skill.Tentacles,
                ["Thick Skull"] = Skill.ThickSkull,
                ["Throw Team-Mate"] = Skill.ThrowTeamMate,
                ["Timmm-ber!"] = Skill.Timmmber,
                ["Titchy"] = Skill.Titchy,
                ["Two Heads"] = Skill.TwoHeads,
                ["Very Long Legs"] = Skill.VeryLongLegs,
                ["Weeping Dagger"] = Skill.WeepingDagger,
                ["Wild Animal"] = Skill.WildAnimal,
                ["Wrestle"] = Skill.Wrestle,
                ["+MA"] = Skill.PlusMa,
                ["-MA"] = Skill.MinusMa,
                ["+ST"] = Skill.PlusSt,
                ["-ST"] = Skill.MinusSt,
                ["+AG"] = Skill.PlusAg,
                ["-AG"] = Skill.MinusAg,
                ["+AV"] = Skill.PlusAv,
                ["-AV"] = Skill.MinusAv,
            };
        }

        public static Skill AsSkill(this FFBEnumeration ffbEnum)
        {
            return Skills.ContainsKey(ffbEnum.key) ? Skills[ffbEnum.key] : null;
        }
    }
}
