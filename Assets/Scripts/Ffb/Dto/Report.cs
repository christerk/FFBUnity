using Fumbbl.UI;

namespace Fumbbl.Dto
{
    public abstract class Report : ReflectedGenerator<string>
    {
        public Report(string key) : base(key) { }
    }
}
