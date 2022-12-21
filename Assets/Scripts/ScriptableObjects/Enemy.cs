using UnityEngine;

namespace EnterKratos.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Enemy")]
    public class Enemy : ScriptableObject
    {
        public float detectionRadius;
        public Color detectionGizmoColour;
        public float attackRadius;
        public Color attackGizmoColour;
        public int attackDamage;
    }
}