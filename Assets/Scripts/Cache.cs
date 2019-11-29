using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;
using UnityEngine;

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
    
        public delegate IEnumerator testingdel(string key, object target, CacheObject<T> t );

        public IEnumerator GetAsync(string key, object target, testingdel func)
        {
            if(!cache.ContainsKey(key))
            {
                CacheObject<T> cacheObject = new CacheObject<T>();
                yield return func(key, target, cacheObject);
                 
                Debug.Log("Cache Miss for: " + key);
                if(cacheObject._item != null)
                {
                    Debug.Log("Cache stored for: " + key);
                    cache[key] = cacheObject;
                }
            }
            else
            {
                Debug.Log("Cache Hit for: " + key);
                target = cache[key]._item;
            }
        }

        public void ClearAll()
        {
            cache.Clear();
        }
    }
}
