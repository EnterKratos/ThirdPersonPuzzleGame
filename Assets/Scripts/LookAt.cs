using UnityEngine;

namespace EnterKratos
{
    public class LookAt : MonoBehaviour
    {
        [SerializeField]
        private Transform target;

        public void SetTarget(Transform newTarget)
        {
            target = newTarget;
        }

        private void Update()
        {
            transform.LookAt(target);
        }
    }
}
