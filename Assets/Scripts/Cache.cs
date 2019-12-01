using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;
using UnityEngine;
using System.Threading.Tasks;

namespace Fumbbl.Lib
{
    public class CacheObject<T>
    {
        public CacheObject()
        {
            _created = DateTime.Now;
        }

        public CacheObject(T item)
        {
            _item = item;
            _created = DateTime.Now;
        }

        public T           _item {get; set;}

        private DateTime    _created;
    }


    public class Cache<T>
    {
       
        private ConcurrentDictionary<string, CacheObject<T>> cache = new ConcurrentDictionary<string, CacheObject<T>>();


        public void Set(string key, T item)
        {
            cache[key] = new CacheObject<T>(item);
        }
    
        public delegate Task<T> GetCacheObjectAsync(string key);

        public async Task<T> GetAsync(string key, GetCacheObjectAsync func)
        {
            CacheObject<T> cacheObject = new CacheObject<T>();
            if(!cache.ContainsKey(key))
            {
                cacheObject._item = await func(key); 
                cache.TryAdd(key, cacheObject);
            }
            cache.TryGetValue(key, out cacheObject);
            return cacheObject._item;       
        }

        public void ClearAll()
        {
            cache.Clear();
        }
    }
}
