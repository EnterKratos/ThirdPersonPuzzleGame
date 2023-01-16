using EnterKratos.Extensions;
using UnityEngine;
using Random = UnityEngine.Random;

namespace EnterKratos
{
    [RequireComponent(typeof(Collider))]
    public class Health : MonoBehaviour
    {
        [SerializeField]
        private int min;

        [SerializeField]
        private int max;

        [SerializeField]
        private LayerMask groundedLayers;

        private int _value;
        private bool _grounded;
        private Collider _triggerCollider;

        private void OnEnable()
        {
            _value = Random.Range(min, max);
            var colliders = GetComponents<Collider>();
            colliders.AssertTrigger();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (groundedLayers.Includes(other.gameObject.layer))
            {
               _grounded = true;
               return;
            }

            if (!_grounded || !other.gameObject.IsPlayer())
            {
                return;
            }

            var healthSystem = other.GetComponent<HealthSystem>();
            healthSystem.Heal(_value);
            Destroy(gameObject);
        }
    }
}
