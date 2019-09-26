using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid.MVC
{
    public abstract class Observer : IObserver
    {
        private readonly List<IObservable> _observers = new List<IObservable>(); 
    
        public void AddObserver(IObservable observable)
        {
            var index = _observers.FindIndex(x => x.GetHashCode() == observable.GetHashCode());
            if(index != -1) Debug.LogError("MVC Subscribe duplication");
            else _observers.Add(observable);
        }

        public void RemoveObserver(IObservable observable)
        {
            var index = _observers.FindIndex(x => x.GetHashCode() == observable.GetHashCode());
            if(index == -1) Debug.Log("MVC Observer not fund, unsubscribe failed.");
            else _observers.Remove(observable);
        }

        public void SetChanged()
        {
            _observers.ForEach(x => x.OnObjectChanged(this));
        }
    }
}
