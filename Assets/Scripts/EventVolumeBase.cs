using EnterKratos.Extensions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace EnterKratos
{
    [RequireComponent(typeof(Collider))]
    public class EventVolumeBase<T> : MonoBehaviour
    {
        [FormerlySerializedAs("onPlayerEnter")] [SerializeField]
        protected UnityEvent<T> onEnter;

        [FormerlySerializedAs("onPlayerExit")] [SerializeField]
        protected UnityEvent<T> onExit;

        private void Awake()
        {
            GetComponents<Collider>().AssertTrigger();
        }
    }
}