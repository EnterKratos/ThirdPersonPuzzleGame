using EnterKratos.ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;

namespace EnterKratos
{
    public class PlayerDetector : MonoBehaviour
    {
        [SerializeField]
        private Enemy enemy;

        [SerializeField]
        private LayerMask layerMask;

        [SerializeField]
        private UnityEvent onPlayerDetected;

        [SerializeField]
        private bool trigger;

        private const int BufferSize = 1;
        private Collider[] _colliderBuffer;

        private void Awake()
        {
            _colliderBuffer = new Collider[BufferSize];
        }

        private void Update()
        {
            var foundColliders = Physics.OverlapSphereNonAlloc(transform.position, enemy.detectionRadius, _colliderBuffer, layerMask);
            if (foundColliders > 0 || trigger)
            {
                AttackPlayer();
            }
        }

        private void AttackPlayer()
        {
            onPlayerDetected.Invoke();
            trigger = false;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, enemy.detectionRadius);
        }
    }
}
