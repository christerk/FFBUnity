namespace Fumbbl.Model.Types
{
    public class SeriousInjury : FfbEnumerationFactory
    {
        public string ButtonText;
        public string Description;
        public string Recovery;
        public bool Lasting;
        public InjuryAttribute InjuryAttribute;

        public SeriousInjury(string name) : base(name) { }

        public static SeriousInjury BrokenRibsMNG = new SeriousInjury("Broken Ribs (MNG)") { ButtonText = "Broken Ribs (Miss next game)", Description = "has broken some ribs (Miss next game)", Recovery = "is recovering from broken ribs", Lasting = false, InjuryAttribute = null };
        public static SeriousInjury GroinStrainMNG = new SeriousInjury("Groin Strain (MNG)") { ButtonText = "Groin Strain (Miss next game)", Description = "has got a groin strain (Miss next game)", Recovery = "is recovering from a groin strain", Lasting = false, InjuryAttribute = null };
        public static SeriousInjury GougedEyeMNG = new SeriousInjury("Gouged Eye (MNG)") { ButtonText = "Gouged Eye (Miss next game)", Description = "has got a gouged eye (Miss next game)", Recovery = "is recovering from a gouged eye", Lasting = false, InjuryAttribute = null };
        public static SeriousInjury BrokenJawMNG = new SeriousInjury("Broken Jaw (MNG)") { ButtonText = "Broken Jaw (Miss next game)", Description = "has got a broken jaw (Miss next game)", Recovery = "is recovering from a broken jaw", Lasting = false, InjuryAttribute = null };
        public static SeriousInjury FracturedArmMNG = new SeriousInjury("Fractured Arm (MNG)") { ButtonText = "Fractured Arm (Miss next game)", Description = "has got a fractured arm (Miss next game)", Recovery = "is recovering from a fractured arm", Lasting = false, InjuryAttribute = null };
        public static SeriousInjury FracturedLegMNG = new SeriousInjury("Fractured Leg (MNG)") { ButtonText = "Fractured Leg (Miss next game)", Description = "has got a fractured leg (Miss next game)", Recovery = "is recovering from a fractured leg", Lasting = false, InjuryAttribute = null };
        public static SeriousInjury SmashedHandMNG = new SeriousInjury("Smashed Hand (MNG)") { ButtonText = "Smashed Hand (Miss next game)", Description = "has got a smashed hand (Miss next game)", Recovery = "is recovering from a smashed hand", Lasting = false, InjuryAttribute = null };
        public static SeriousInjury PinchedNerveMNG = new SeriousInjury("Pinched Nerve (MNG)") { ButtonText = "Pinched Nerve (Miss next game)", Description = "has got a pinched nerve (Miss next game)", Recovery = "is recovering from a pinched nerve", Lasting = false, InjuryAttribute = null };
        public static SeriousInjury DamagedBackNI = new SeriousInjury("Damaged Back (NI)") { ButtonText = "Damaged Back (Niggling Injury)", Description = "has got a damaged back (Niggling Injury)", Recovery = "is recovering from a damaged back (Niggling Injury)", Lasting = true, InjuryAttribute = InjuryAttribute.NI };
        public static SeriousInjury SmashedKneeNI = new SeriousInjury("Smashed Knee (NI)") { ButtonText = "Smashed Knee (Niggling Injury)", Description = "has got a smashed knee (Niggling Injury)", Recovery = "is recovering from a smashed knee (Niggling Injury)", Lasting = true, InjuryAttribute = InjuryAttribute.NI };
        public static SeriousInjury SmashedHipMA = new SeriousInjury("Smashed Hip (-MA)") { ButtonText = "Smashed Hip (-1 MA)", Description = "has got a smashed hip (-1 MA)", Recovery = "is recovering from a smashed hip (-1 MA)", Lasting = true, InjuryAttribute = InjuryAttribute.MA };
        public static SeriousInjury SmashedAnkleMA = new SeriousInjury("Smashed Ankle (-MA)") { ButtonText = "Smashed Ankle (-1 MA)", Description = "has got a smashed ankle (-1 MA)", Recovery = "is recovering from a smashed ankle (-1 MA)", Lasting = true, InjuryAttribute = InjuryAttribute.MA };
        public static SeriousInjury SeriousConcussionAV = new SeriousInjury("Serious Concussion (-AV)") { ButtonText = "Serious Concussion (-1 AV)", Description = "has got a serious concussion (-1 AV)", Recovery = "is recovering from a serious concussion (-1 AV)", Lasting = true, InjuryAttribute = InjuryAttribute.AV };
        public static SeriousInjury FracturedSkullAV = new SeriousInjury("Fractured Skull (-AV)") { ButtonText = "Fractured Skull (-1 AV)", Description = "has got a fractured skull (-1 AV)", Recovery = "is recovering from a fractured skull (-1 AV)", Lasting = true, InjuryAttribute = InjuryAttribute.AV };
        public static SeriousInjury BrokenNeckAG = new SeriousInjury("Broken Neck (-AG)") { ButtonText = "Broken Neck (-1 AG)", Description = "has got a broken neck (-1 AG)", Recovery = "is recovering from a broken neck (-1 AG)", Lasting = true, InjuryAttribute = InjuryAttribute.AG };
        public static SeriousInjury SmashedCollarBoneST = new SeriousInjury("Smashed Collar Bone(-ST)") { ButtonText = "Smashed Collar Bone(-1 ST)", Description = "has got a smashed collar bone(-1 ST)", Recovery = " is recovering from a smashed collar bone(-1 ST)", Lasting = true, InjuryAttribute = InjuryAttribute.ST };
        public static SeriousInjury DeadRIP = new SeriousInjury("Dead (RIP)") { ButtonText = "Dead (RIP)", Description = "is dead", Recovery = "is dead", Lasting = true, InjuryAttribute = null };
        public static SeriousInjury PoisonedMNG = new SeriousInjury("Poisoned (MNG)") { ButtonText = "Poisoned (Miss next game)", Description = "has been poisoned (Miss next game)", Recovery = "is recovering from being poisoned", Lasting = false, InjuryAttribute = null };
    }
}
