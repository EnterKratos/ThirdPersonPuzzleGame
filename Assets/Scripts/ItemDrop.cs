using UnityEngine;

namespace EnterKratos
{
    public class ItemDrop : MonoBehaviour
    {
        [SerializeField]
        private GameObject prefab;

        [SerializeField]
        private float directionalForce;

        [SerializeField]
        private float upwardForce;

        public void Drop()
        {
            var item = Instantiate(prefab, transform.position, Quaternion.identity);
            var rigidBody = item.GetComponent<Rigidbody>();

            var playerForward =
                GameObject.FindWithTag("Player")
                .transform.forward.normalized;

            rigidBody.AddRelativeForce(playerForward * directionalForce, ForceMode.Impulse);
            rigidBody.AddRelativeForce(Vector3.up * upwardForce, ForceMode.Impulse);
        }
    }
}
