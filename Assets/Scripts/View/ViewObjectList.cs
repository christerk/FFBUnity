using System;
using System.Collections.Generic;
using System.Linq;

namespace Fumbbl.View
{
    public class ViewObjectList<T>
        where T : ViewObject<T>
    {
        public Dictionary<object, ViewObject<T>> Objects;

        private readonly List<ViewObject<T>> RemovedObjects;

        private readonly Action<T> Constructor;
        private readonly Action<T> Updater;
        private readonly Action<ViewObject<T>> Destructor;

        public ViewObjectList(Action<T> constructor, Action<ViewObject<T>> destructor)
            : this(constructor, null, destructor) { }

        public ViewObjectList(Action<T> constructor, Action<T> updater, Action<ViewObject<T>> destructor)
        {
            Objects = new Dictionary<object, ViewObject<T>>();
            RemovedObjects = new List<ViewObject<T>>();

            Constructor = constructor;
            Updater = updater;
            Destructor = destructor;
        }

        public List<ViewObject<T>> Refresh(IEnumerable<T> newObjects, Action<T> action = null)
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
                    Objects[o.Key].Refresh(o);
                    Updater?.Invoke((T) Objects[o.Key]);
                }
                else
                {
                    Constructor(o);
                    Objects.Add(o.Key, o);
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
                    action?.Invoke((T)o);
                }
            }

            foreach (var key in Objects.Values.Where(o => o.Removed).Select(o => o.Key).ToList())
            {
                Objects.Remove(key);
            }

            return RemovedObjects;
        }
    }
}
