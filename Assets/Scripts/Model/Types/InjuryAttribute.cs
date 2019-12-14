namespace Fumbbl.Model.Types
{
    public class InjuryAttribute : FfbEnumerationFactory
    {
        public int Id { get; private set; }

        public InjuryAttribute(string name) : base(name) { }

        public static InjuryAttribute MA = new InjuryAttribute("MA") { Id = 1 };
        public static InjuryAttribute ST = new InjuryAttribute("ST") { Id = 2 };
        public static InjuryAttribute AG = new InjuryAttribute("AG") { Id = 3 };
        public static InjuryAttribute AV = new InjuryAttribute("AV") { Id = 4 };
        public static InjuryAttribute NI = new InjuryAttribute("NI") { Id = 5 };
    }
}
