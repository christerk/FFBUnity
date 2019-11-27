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


        public void Set(string key, T item)
        {
            cache[key] = new CacheObject(item);
        }

        public bool Get(string key, Func<T> func)
        {
            func();
            if(!cache.ContainsKey(key))
            {
               return false;
            }

          //  target = cache[key].Get();
            return true;  
        }

        public void ClearAll()
        {
            cache.Clear();
        }
    }
}
