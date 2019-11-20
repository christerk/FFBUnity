namespace Fumbbl.Ffb.Dto
{
    public abstract class ModelChange : ReflectedGenerator<string>
    {
        public ModelChange(string key) : base(key) { }
    }
}
