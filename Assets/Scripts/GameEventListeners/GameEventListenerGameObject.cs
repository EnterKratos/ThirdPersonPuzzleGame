using EnterKratos.ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;

namespace EnterKratos.GameEventListeners
{
    public class GameEventListenerGameObject : GameEventListener<GameObject>
    {
        public GameEventGameObject typedEvent;
        public UnityEvent<GameObject> typedResponse;

        private void Awake()
        {
            Event = typedEvent;
            Response = typedResponse;
        }
    }
}