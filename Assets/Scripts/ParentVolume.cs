using UnityEngine;

namespace EnterKratos
{
    [RequireComponent(typeof(Collider))]
    public class ParentVolume : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                other.transform.parent = transform;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                other.transform.parent = null;
            }
        }
    }
}