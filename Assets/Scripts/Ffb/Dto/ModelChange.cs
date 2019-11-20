using Fumbbl.UI;

namespace Fumbbl.Dto
{
    public abstract class ModelChange : ReflectedGenerator<string>
    {
        public ModelChange(string key) : base(key) { }
    }
}
