using UnityEngine;

namespace EnterKratos
{
    public class Teleporter : MonoBehaviour
    {
        [SerializeField]
        private Transform target;

        public void Teleport(Collider other)
        {
            Teleport(other.gameObject);
        }

        public void Teleport(Rigidbody other)
        {
            Teleport(other.gameObject);

            var speed = other.velocity.magnitude;
            var direction = other.transform.forward;
            other.velocity = speed * direction;
        }

        public void Teleport(GameObject other)
        {
            var otherTransform = other.transform;
            otherTransform.position = target.position;
            otherTransform.rotation = target.rotation;
        }
    }
}
