using EnterKratos.Extensions;
using UnityEngine;

namespace EnterKratos
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField]
        private ScriptableObjects.Weapon weapon;

        private bool _attacking;
        private GameObject _player;

        public int AttackCooldown => weapon.attackCooldown;

        public void SetAttacking(bool value)
        {
            _attacking = value;
        }

        private void Start()
        {
            _player = GameObject.FindGameObjectWithTag(GameObjectExtensions.PlayerTag);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!_attacking || other.gameObject.IsPlayer())
            {
                return;
            }

            var died = other.GetComponent<HealthSystem>()?.Attack(weapon.attackDamage);
            if (died == true)
            {
                other.GetComponent<Hittable>()?.Hit(_player.transform.forward * weapon.attackVelocity);
            }
        }
    }
}