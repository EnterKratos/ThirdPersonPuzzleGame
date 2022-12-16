using UnityEngine;

namespace EnterKratos.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Enemy")]
    public class Enemy : ScriptableObject
    {
        public float detectionRadius;
    }
}