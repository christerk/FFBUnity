using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;
using UnityEngine;

namespace Fumbbl.Lib
{

    public class Cache<T>
    {
        private class CacheObject
        {
            public CacheObject(T item)
            {
                _item = item;
                _created = DateTime.Now;
            }

            public T Get() { return _item;}

            private T           _item;
            private DateTime    _created;
        }

        private ConcurrentDictionary<string, CacheObject> cache = new ConcurrentDictionary<string, CacheObject>();

        public T GetOrCreate(string key, Func<T> create)
        {
            if(!cache.ContainsKey(key))
            {
                T cacheItem;
                create(cacheItem);
                CacheObject item = new CacheObject(cacheItem);
                cache[key] = item;
            }
            return cache[key].Get();
        }

        public void ClearAll()
        {
            cache.Clear();
        }
    }
}
