using UnityEngine;

namespace EnterKratos
{
    public class Hazard : MonoBehaviour
    {
        [SerializeField]
        private int damage;

        public void Damage(Collider other)
        {
            other.GetComponent<HealthSystem>()?.Attack(damage);
        }
    }
}