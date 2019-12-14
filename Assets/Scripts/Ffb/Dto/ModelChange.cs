namespace Fumbbl.Ffb.Dto
{
    public abstract class ModelChange : ReflectedGenerator<string>
    {
        public string modelChangeId;
        public string modelChangeKey;

        public ModelChange(string key) : base(key) { }
    }
}
