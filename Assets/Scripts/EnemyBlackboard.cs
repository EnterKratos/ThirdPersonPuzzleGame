using System;
using EnterKratos.ScriptableObjects;
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
        public float patrolPointTolerance;
        public Transform[] patrolPoints;
        public LayerMask playerDetectionMask;
        public static readonly int MovingParam = Animator.StringToHash("Moving");
        public static readonly int AttackParam = Animator.StringToHash("Attack");
    }
}