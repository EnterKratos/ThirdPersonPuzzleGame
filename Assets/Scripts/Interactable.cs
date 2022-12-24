using EnterKratos.ScriptableObjects;
using UnityEngine;
using UnityEngine.InputSystem;

namespace EnterKratos
{
    public class Interactable : MonoBehaviour
    {
        [SerializeField]
        private new Collider collider;

        [SerializeField]
        private GameEvent onInteract;

        private const string PlayerTag = "Player";
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
            if (!collider.isTrigger)
            {
                Debug.LogError("Collider must be a trigger");
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(PlayerTag))
            {
                _inRange = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(PlayerTag))
            {
                _inRange = false;
            }
        }
    }
}
