using EnterKratos.Health;
using UnityEngine;

namespace EnterKratos.ScriptableObjects
{
    [CreateAssetMenu]
    public class Player : ScriptableObject, IKillable
    {
        public int maxHealth;
        public int MaxHealth => maxHealth;
        public float damageCooldown;
        public float DamageCooldown => damageCooldown;
    }
}