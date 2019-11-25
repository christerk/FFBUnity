namespace Fumbbl.Ffb.Dto
{
    public abstract class NetCommand : ReflectedGenerator<string>
    {
        public NetCommand(string key) : base(key) { }
    }
}
