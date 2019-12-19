namespace Fumbbl.View
{
    public interface IKeyedObject<T>
    {
        object Key { get; }
        void Refresh(T data);
    }
}