using UnityEngine;
using UnityEngine.Events;

namespace EnterKratos
{
    public class OnStartEvent : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent @event;

        private void Start()
        {
            @event.Invoke();
        }
    }
}