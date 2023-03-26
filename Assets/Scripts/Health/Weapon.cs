using EnterKratos.Extensions;
using EnterKratos.ScriptableObjects;
using UnityEngine;

namespace EnterKratos.Health
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField]
        private ScriptableObjects.Weapon weapon;

        [SerializeField]
        private Collectable collectable;

        private bool _attacking;
        private GameObject _player;

        public int AttackCooldown => weapon.attackCooldown;

        public void SetAttacking(bool value)
        {
            _attacking = value;
        }

        public void CollectableCollected(Collectable collectedCollectable)
        {
            if (collectedCollectable == collectable)
            {
                gameObject.SetActive(true);
            }
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