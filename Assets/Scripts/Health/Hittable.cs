using UnityEngine;

namespace EnterKratos.Health
{
    [RequireComponent(typeof(Rigidbody))]
    public class Hittable : MonoBehaviour
    {
        private Rigidbody _rigidBody;

        public void Hit(Vector3 hitVelocity)
        {
            if (enabled)
            {
                _rigidBody.AddForce(hitVelocity, ForceMode.Impulse);
            }
        }

        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody>();
        }

        // ReSharper disable once Unity.RedundantEventFunction
        private void Start()
        {
            // Required for the inspector to display the enabled checkbox
        }
    }
}