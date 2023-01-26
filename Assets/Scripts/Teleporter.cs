using UnityEngine;

namespace EnterKratos
{
    public class Teleporter : MonoBehaviour
    {
        [SerializeField]
        private Transform target;

        public void Teleport(Collider other)
        {
            var otherTransform = other.transform;
            otherTransform.position = target.position;
            otherTransform.rotation = target.rotation;
        }
    }
}
