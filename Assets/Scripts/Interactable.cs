using EnterKratos.Extensions;
using EnterKratos.ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;

namespace EnterKratos
{
    [RequireComponent(typeof(Collider))]
    public class Interactable : MonoBehaviour
    {
        [SerializeField]
        private GameEvent onInteract;

        [SerializeField]
        private UnityEvent onInteractUnityEvent;

        [SerializeField]
        private bool singleUse;

        [Header("Gizmo Settings")]
        [SerializeField]
        private float radius = 0.1f;

        [SerializeField]
        private Color unusedColour = Color.green;

        [SerializeField]
        private Color usedColour = Color.blue;

        private bool _inRange;
        private bool _used;

        public void Interact()
        {
            if (!_inRange || (singleUse && _used))
            {
                return;
            }

            onInteract.Raise();
            onInteractUnityEvent.Invoke();
            _used = true;
        }

        private void Awake()
        {
            GetComponents<Collider>().AssertTrigger();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.IsPlayer())
            {
                _inRange = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.IsPlayer())
            {
                _inRange = false;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = _used ? usedColour : unusedColour;
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}
