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
        public Transform player;
        public float idleWaitTime;
        public float patrolPointTolerance;
        public Transform[] patrolPoints;
        public LayerMask playerDetectionMask;
    }
}