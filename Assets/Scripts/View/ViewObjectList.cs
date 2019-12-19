using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Fumbbl.View
{
    public class ViewObjectList<T>
        where T : IKeyedObject<T>
    {
        public Dictionary<object, ViewObject<T>> Objects;

        private readonly List<ViewObject<T>> RemovedObjects;

        protected Func<T, GameObject> Constructor;
        protected Action<ViewObject<T>> Updater;
        protected Action<ViewObject<T>> Destructor;

        public ViewObjectList(Func<T, GameObject> constructor, Action<ViewObject<T>> destructor)
            : this(constructor, null, destructor) { }

        public ViewObjectList(Func<T, GameObject> constructor, Action<ViewObject<T>> updater, Action<ViewObject<T>> destructor)
        {
            Objects = new Dictionary<object, ViewObject<T>>();
            RemovedObjects = new List<ViewObject<T>>();

            Constructor = constructor;
            Updater = updater;
            Destructor = destructor;
        }

        public List<ViewObject<T>> Refresh(IEnumerable<T> newObjects)
        {
            foreach (var o in Objects.Values)
            {
                o.Removed = true;
            }

            foreach (var o in newObjects)
            {
                if (Objects.ContainsKey(o.Key))
                {
                    Objects[o.Key].Removed = false;
                    Objects[o.Key].ModelObject.Refresh(o);
                }
                else
                {
                    var gameObject = Constructor(o);
                    var viewObject = new ViewObject<T>(o, gameObject);
                    Objects.Add(o.Key, viewObject);
                }
            }

            foreach (var o in Objects.Values)
            {
                if (o.Removed && o.GameObject != null)
                {
                    Destructor(o);
                    RemovedObjects.Add(o);
                } else
                {
                    Updater?.Invoke(o);
                }
            }

            foreach (var key in Objects.Values.Where(o => o.Removed).Select(o => o.ModelObject.Key).ToList())
            {
                Objects.Remove(key);
            }

            return RemovedObjects;
        }
    }
}
