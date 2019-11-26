namespace Fumbbl.Model
{
    public class InjuryAttribute
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public static InjuryAttribute MA = new InjuryAttribute() { Id = 1, Name = "MA" };
        public static InjuryAttribute ST = new InjuryAttribute() { Id = 2, Name = "ST" };
        public static InjuryAttribute AG = new InjuryAttribute() { Id = 3, Name = "AG" };
        public static InjuryAttribute AV = new InjuryAttribute() { Id = 4, Name = "AV" };
        public static InjuryAttribute NI = new InjuryAttribute() { Id = 5, Name = "NI" };
    }
}