using System;
using EnterKratos.ScriptableObjects;
using TNRD;
using UnityEngine;
using UnityEngine.AI;

namespace EnterKratos
{
    [Serializable]
    public class EnemyBlackboard
    {
        public Enemy enemy;
        public NavMeshAgent navMeshAgent;
        public Animator animator;
        public Transform player;
        public float idleWaitTime;
        public LayerMask playerDetectionMask;
        public SerializableInterface<IPatrolPointProvider> patrolPointProvider;
        public static readonly int MovingParam = Animator.StringToHash("Moving");
        public static readonly int AttackParam = Animator.StringToHash("Attack");
        public HealthSystem PlayerHealthSystem { get; private set; }

        public void OnEnable()
        {
            PlayerHealthSystem = player.GetComponent<HealthSystem>();
        }
    }
}