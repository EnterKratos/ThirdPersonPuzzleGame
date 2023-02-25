using EnterKratos.ScriptableObjects;
using UnityEngine.Events;

namespace EnterKratos.GameEventListeners
{
    public class GameEventListenerCollectable : GameEventListener<Collectable>
    {
        public GameEventCollectable typedEvent;
        public UnityEvent<Collectable> typedResponse;

        private void Awake()
        {
            Event = typedEvent;
            Response = typedResponse;
        }
    }
}