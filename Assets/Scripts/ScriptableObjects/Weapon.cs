using UnityEngine;

namespace EnterKratos.ScriptableObjects
{
    [CreateAssetMenu]
    public class Weapon : ScriptableObject
    {
        public int attackDamage;
        public int attackCooldown;
        public float attackVelocity;
    }
}