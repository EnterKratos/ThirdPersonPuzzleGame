using UnityEngine;

namespace EnterKratos.ScriptableObjects
{
    [CreateAssetMenu]
    public class Enemy : ScriptableObject, IKillable
    {
        public float detectionRadius;
        public Color detectionGizmoColour;
        public float attackRadius;
        public Color attackGizmoColour;
        public int attackDamage;
        public float rotationSpeed;
        public float idleWaitTime;
        public float chaseTimeout;
        public int maxHealth;
        public int MaxHealth => maxHealth;
        public int damageCooldown;
        public float DamageCooldown => damageCooldown;
        public float deathTimeout;
    }
}