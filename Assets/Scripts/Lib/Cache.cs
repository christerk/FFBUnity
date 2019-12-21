using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Fumbbl.Lib
{
    public class CacheObject<T>
    {
        public CacheObject()
        {
            Created = DateTime.Now;
        }

        public CacheObject(T item)
        {
            Item = item;
            Created = DateTime.Now;
        }

        public T Item { get; set; }

        private readonly DateTime Created;
    }


    public class Cache<T>
    {
        private readonly ConcurrentDictionary<string, CacheObject<T>> cache = new ConcurrentDictionary<string, CacheObject<T>>();
        public Func<string, Task<T>> Generator { get; }

        public Cache(Func<string, Task<T>> generator)
        {
            Generator = generator;
        }

        public void Set(string key, T item)
        {
            cache[key] = new CacheObject<T>(item);
        }

        public T Get(string key)
        {
            if(key != null)
            {
                CacheObject<T> cacheObject;
                if(cache.TryGetValue(key, out cacheObject))
                {
                    return cacheObject.Item;
                }
            }
            return default(T);
        }

        public async Task<T> GetAsync(string key, Action<T> completed = null)
        {
            CacheObject<T> cacheObject = new CacheObject<T>();
            if(!cache.ContainsKey(key))
            {
                cacheObject.Item = await Generator(key);
                cache.TryAdd(key, cacheObject);
            }
            cache.TryGetValue(key, out cacheObject);

            completed?.Invoke(cacheObject.Item);

            return cacheObject.Item;
        }

        public void ClearAll()
        {
            cache.Clear();
        }
    }
}
