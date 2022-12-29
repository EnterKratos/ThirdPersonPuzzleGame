using EnterKratos.Extensions;
using EnterKratos.ScriptableObjects;
using UnityEngine;

namespace EnterKratos
{
    public class Interactable : MonoBehaviour
    {
        [SerializeField]
        private new Collider collider;

        [SerializeField]
        private GameEvent onInteract;

        private bool _inRange;

        public void Interact()
        {
            if (_inRange)
            {
                onInteract.Raise();
            }
        }

        private void Awake()
        {
            collider.AssertTrigger();
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
    }
}
