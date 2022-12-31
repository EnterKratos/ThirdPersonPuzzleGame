using UnityEngine;

namespace EnterKratos
{
    public class ColliderParent: MonoBehaviour
    {
        public void SetAsColliderParent(Collider collider)
        {
            collider.transform.parent = transform;
        }

        public void Unparent(Collider collider)
        {
            collider.transform.parent = null;
        }
    }
}