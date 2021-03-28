using UnityEngine;

namespace Fumbbl.View
{
    public class ViewObject<T>
        where T : IKeyedObject<T>
    {
        public bool Removed;
        public GameObject GameObject;
        public T ModelObject;
        public object Key { get; private set; }

        public ViewObject(T modelObject, GameObject gameObject)
        {
            ModelObject = modelObject;
            GameObject = gameObject;
            Key = modelObject.Key;
        }
        //public abstract object Key { get; }
        //public abstract void Refresh(T data);
    }
}