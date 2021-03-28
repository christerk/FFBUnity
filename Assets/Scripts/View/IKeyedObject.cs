namespace Fumbbl.View
{
    public interface IKeyedObject<T>
        where T : IKeyedObject<T>
    {
        object Key { get; }

        void Set(T o);
        void Unset();
    }
}