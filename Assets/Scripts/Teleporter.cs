using UnityEngine;

namespace EnterKratos
{
    public class Teleporter : MonoBehaviour
    {
        [SerializeField]
        private Transform target;

        public void Teleport(Collider other)
        {
            other.transform.position = target.position;
        }
    }
}
