using UnityEngine;
using UnityEngine.Events;

namespace EnterKratos
{
    public class AnimationEventListener : MonoBehaviour
    {
        [SerializeField]
        private string eventName;

        [SerializeField]
        private UnityEvent @event;

        public void OnAnimationEvent(string name)
        {
            if (name == eventName)
            {
                @event.Invoke();
            }
        }
    }
}
