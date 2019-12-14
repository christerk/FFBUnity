namespace Fumbbl
{
    public class ReflectedGenerator<T> : IReflectedObject<T>
    {
        private readonly T Key;

        public ReflectedGenerator(T key)
        {
            Key = key;
        }

        public T GetReflectedKey()
        {
            return Key;
        }

    }
}
