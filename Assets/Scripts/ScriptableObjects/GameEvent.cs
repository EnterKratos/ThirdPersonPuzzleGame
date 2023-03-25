using System.Collections.Generic;
using EnterKratos.GameEventListeners;
using UnityEngine;

namespace EnterKratos.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Events/Game Event")]
    public class GameEvent : ScriptableObject
    {
        private readonly List<GameEventListener> _listeners = new();

        public void Raise()
        {
            for(var i = _listeners.Count -1; i >= 0; i--)
                _listeners[i].OnEventRaised();
        }

        public void RegisterListener(GameEventListener listener) => _listeners.Add(listener);

        public void UnregisterListener(GameEventListener listener) => _listeners.Remove(listener);
    }

    public abstract class GameEvent<T> : ScriptableObject
    {
        private readonly List<GameEventListener<T>> _listeners = new();

        public void Raise(T value)
        {
            for(var i = _listeners.Count -1; i >= 0; i--)
                _listeners[i].OnEventRaised(value);
        }

        public void RegisterListener(GameEventListener<T> listener) => _listeners.Add(listener);

        public void UnregisterListener(GameEventListener<T> listener) => _listeners.Remove(listener);
    }
}