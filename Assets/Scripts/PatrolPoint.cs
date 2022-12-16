using UnityEngine;

namespace EnterKratos
{
    public class PatrolPoint : MonoBehaviour
    {
        [SerializeField]
        private float radius = 1;

        [SerializeField]
        private Color colour = Color.green;

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = colour;
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}