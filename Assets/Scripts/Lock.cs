using EnterKratos.Extensions;
using EnterKratos.ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;

namespace EnterKratos
{
    public class Lock : MonoBehaviour
    {
        [SerializeField]
        private Collectable key;

        [SerializeField]
        private UnityEvent onUnlock;

        private bool _locked = true;

        public void Unlock()
        {
            _locked = false;
            onUnlock.Invoke();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!_locked ||
                !other.gameObject.IsPlayer() ||
                !other.TryGetComponent<Inventory>(out var inventory))
            {
                return;
            }

            if (inventory.Remove(key))
            {
                Unlock();
            }
        }
    }
}