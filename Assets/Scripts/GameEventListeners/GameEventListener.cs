using EnterKratos.ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;

namespace EnterKratos.GameEventListeners
{
    public class GameEventListener : MonoBehaviour
    {
        public GameEvent @event;
        public UnityEvent response;

        private void OnEnable() => @event.RegisterListener(this);

        private void OnDisable() => @event.UnregisterListener(this);

        public void OnEventRaised() => response.Invoke();
    }

    public abstract class GameEventListener<T> : MonoBehaviour
    {
        protected GameEvent<T> Event;
        protected UnityEvent<T> Response;

        private void OnEnable() => Event.RegisterListener(this);

        private void OnDisable() => Event.UnregisterListener(this);

        public virtual void OnEventRaised(T value) => Response.Invoke(value);
    }
}