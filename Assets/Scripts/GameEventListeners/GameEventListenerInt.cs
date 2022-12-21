using EnterKratos.ScriptableObjects;
using UnityEngine.Events;

namespace EnterKratos.GameEventListeners
{
    public class GameEventListenerInt : GameEventListener<int>
    {
        public GameEventInt typedEvent;
        public UnityEvent<int> typedResponse;

        private void Awake()
        {
            Event = typedEvent;
            Response = typedResponse;
        }
    }
}