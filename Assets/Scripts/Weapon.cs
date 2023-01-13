using EnterKratos.Extensions;
using UnityEngine;

namespace EnterKratos
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField]
        private ScriptableObjects.Weapon weapon;

        private bool _attacking;

        public int AttackCooldown => weapon.attackCooldown;

        public void SetAttacking(bool value)
        {
            _attacking = value;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!_attacking || other.gameObject.IsPlayer())
            {
                return;
            }

            foreach (var healthSystem in other.GetComponents<HealthSystem>())
            {
                healthSystem.Attack(weapon.attackDamage);
            }
        }
    }
}