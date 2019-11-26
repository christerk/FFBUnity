using System.Collections.Generic;

namespace Fumbbl.Model
{
    public class SeriousInjury
    {
        public string Name { get; set; }
        public string ButtonText { get; set; }
        public string Description { get; set; }
        public string Recovery { get; set; }
        public bool Lasting { get; set; }
        public InjuryAttribute InjuryAttribute { get; set; }

        public SeriousInjury(string name, string buttonText, string description, string recovery, bool lasting, InjuryAttribute injuryAttribute)
        {
            Name = name;
            ButtonText = buttonText;
            Description = description;
            Recovery = recovery;
            Lasting = lasting;
            InjuryAttribute = injuryAttribute;
        }
    }

    public static class SeriousInjuryExtensions
    {
        private static readonly Dictionary<string, SeriousInjury> SeriousInjuries = new Dictionary<string, SeriousInjury>();

        static SeriousInjuryExtensions()
        {
            SeriousInjuries = new Dictionary<string, SeriousInjury>()
            {
                ["Broken Ribs (MNG)"] = new SeriousInjury("Broken Ribs (MNG)", "Broken Ribs (Miss next game)", "has broken some ribs (Miss next game)", "is recovering from broken ribs", false, null),
                ["Groin Strain (MNG)"] = new SeriousInjury("Groin Strain (MNG)", "Groin Strain (Miss next game)", "has got a groin strain (Miss next game)", "is recovering from a groin strain", false, null),
                ["Gouged Eye (MNG)"] = new SeriousInjury("Gouged Eye (MNG)", "Gouged Eye (Miss next game)", "has got a gouged eye (Miss next game)", "is recovering from a gouged eye", false, null),
                ["Broken Jaw (MNG)"] = new SeriousInjury("Broken Jaw (MNG)", "Broken Jaw (Miss next game)", "has got a broken jaw (Miss next game)", "is recovering from a broken jaw", false, null),
                ["Fractured Arm (MNG)"] = new SeriousInjury("Fractured Arm (MNG)", "Fractured Arm (Miss next game)", "has got a fractured arm (Miss next game)", "is recovering from a fractured arm", false, null),
                ["Fractured Leg (MNG)"] = new SeriousInjury("Fractured Leg (MNG)", "Fractured Leg (Miss next game)", "has got a fractured leg (Miss next game)", "is recovering from a fractured leg", false, null),
                ["Smashed Hand (MNG)"] = new SeriousInjury("Smashed Hand (MNG)", "Smashed Hand (Miss next game)", "has got a smashed hand (Miss next game)", "is recovering from a smashed hand", false, null),
                ["Pinched Nerve (MNG)"] = new SeriousInjury("Pinched Nerve (MNG)", "Pinched Nerve (Miss next game)", "has got a pinched nerve (Miss next game)", "is recovering from a pinched nerve", false, null),
                ["Damaged Back (NI)"] = new SeriousInjury("Damaged Back (NI)", "Damaged Back (Niggling Injury)", "has got a damaged back (Niggling Injury)", "is recovering from a damaged back (Niggling Injury)", true, InjuryAttribute.NI),
                ["Smashed Knee (NI)"] = new SeriousInjury("Smashed Knee (NI)", "Smashed Knee (Niggling Injury)", "has got a smashed knee (Niggling Injury)", "is recovering from a smashed knee (Niggling Injury)", true, InjuryAttribute.NI),
                ["Smashed Hip (-MA)"] = new SeriousInjury("Smashed Hip (-MA)", "Smashed Hip (-1 MA)", "has got a smashed hip (-1 MA)", "is recovering from a smashed hip (-1 MA)", true, InjuryAttribute.MA),
                ["Smashed Ankle (-MA)"] = new SeriousInjury("Smashed Ankle (-MA)", "Smashed Ankle (-1 MA)", "has got a smashed ankle (-1 MA)", "is recovering from a smashed ankle (-1 MA)", true, InjuryAttribute.MA),
                ["Serious Concussion (-AV)"] = new SeriousInjury("Serious Concussion (-AV)", "Serious Concussion (-1 AV)", "has got a serious concussion (-1 AV)", "is recovering from a serious concussion (-1 AV)", true, InjuryAttribute.AV),
                ["Fractured Skull (-AV)"] = new SeriousInjury("Fractured Skull (-AV)", "Fractured Skull (-1 AV)", "has got a fractured skull (-1 AV)", "is recovering from a fractured skull (-1 AV)", true, InjuryAttribute.AV),
                ["Broken Neck (-AG)"] = new SeriousInjury("Broken Neck (-AG)", "Broken Neck (-1 AG)", "has got a broken neck (-1 AG)", "is recovering from a broken neck (-1 AG)", true, InjuryAttribute.AG),
                ["Smashed Collar Bone (-ST)"] = new SeriousInjury("Smashed Collar Bone(-ST)", "Smashed Collar Bone(-1 ST)", "has got a smashed collar bone(-1 ST)", " is recovering from a smashed collar bone(-1 ST)", true, InjuryAttribute.ST),
                ["Dead (RIP)"] = new SeriousInjury("Dead (RIP)", "Dead (RIP)", "is dead", "is dead", true, null),
                ["Poisoned (MNG)"] = new SeriousInjury("Poisoned (MNG)", "Poisoned (Miss next game)", "has been poisoned (Miss next game)", "is recovering from being poisoned", false, null),

            };
        }

        public static SeriousInjury AsSeriousInjury(this FFBEnumeration ffbEnum)
        {
            return SeriousInjuries.ContainsKey(ffbEnum.key) ? SeriousInjuries[ffbEnum.key] : null;
        }
    }
}
