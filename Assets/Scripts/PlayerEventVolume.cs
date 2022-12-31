using EnterKratos.Extensions;
using UnityEngine;
using UnityEngine.Events;

namespace EnterKratos
{
    [RequireComponent(typeof(Collider))]
    public class PlayerEventVolume : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent<Collider> onPlayerEnter;

        [SerializeField]
        private UnityEvent<Collider> onPlayerExit;

        private void Awake()
        {
            GetComponents<Collider>().AssertTrigger();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.IsPlayer())
            {
                onPlayerEnter.Invoke(other);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.IsPlayer())
            {
                onPlayerExit.Invoke(other);
            }
        }
    }
}