using UnityEngine;

namespace Fumbbl.View
{
    public abstract class ViewObject<T>
    {
        public bool Removed;
        public GameObject GameObject;
        public T Data;

        public abstract object Key { get; }
        public abstract void Refresh(T data);
    }
}