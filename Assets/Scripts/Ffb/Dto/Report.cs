namespace Fumbbl.Ffb.Dto
{
    public abstract class Report : ReflectedGenerator<string>
    {
        public Report(string key) : base(key) { }
    }
}
