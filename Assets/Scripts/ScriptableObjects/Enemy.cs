using UnityEngine;

namespace EnterKratos.ScriptableObjects
{
    [CreateAssetMenu]
    public class Enemy : ScriptableObject
    {
        public float detectionRadius;
        public Color detectionGizmoColour;
        public float attackRadius;
        public Color attackGizmoColour;
        public int attackDamage;
        public float rotationSpeed;
        public float idleWaitTime;
        public float chaseTimeout;
    }
}