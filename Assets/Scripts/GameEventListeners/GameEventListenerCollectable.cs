using EnterKratos.ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;

namespace EnterKratos.GameEventListeners
{
    public class GameEventListenerCollectable : GameEventListener<Collectable>
    {
        public GameEventCollectable typedEvent;
        public UnityEvent<Collectable> typedResponse;

        [Tooltip("Optionally, only invoke if this collectable is received")]
        public Collectable collectable;

        public override void OnEventRaised(Collectable value)
        {
            if (collectable == null || value == collectable)
            {
                Response.Invoke(value);
            }
        }

        private void Awake()
        {
            Event = typedEvent;
            Response = typedResponse;
        }
    }
}