using UnityEngine;

namespace EnterKratos
{
    public class LookAt : MonoBehaviour
    {
        [SerializeField]
        private Transform target;

        private void Update()
        {
            transform.LookAt(target);
        }
    }
}
