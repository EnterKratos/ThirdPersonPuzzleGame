using System;
using EnterKratos.Animation;
using EnterKratos.Patrol;
using EnterKratos.StateMachines.States;
using JetBrains.Annotations;
using UnityEngine;

namespace EnterKratos.StateMachines
{
    public class EnemyStateMachine: StateMachine<EnemyState>, IPatrol
    {
        [SerializeField]
        private EnemyState initialState;

        [SerializeField]
        private EnemyBlackboard blackboard;

        private void OnEnable()
        {
            blackboard.OnEnable();
        }

        public PatrolPoint TargetPatrolPoint
        {
            get
            {
                if (CurrentState is IPatrol patrol)
                {
                    return patrol.TargetPatrolPoint;
                }

                throw new InvalidOperationException("Only valid in patrol state");
            }
        }

        [UsedImplicitly]
        public void AnimationEventAttack()
        {
            CurrentState.HandleEvent((int)EnemyAnimationEvents.Attack);
        }

        public void DrawDetectionRadius()
        {
            Gizmos.color = blackboard.enemy.detectionGizmoColour;
            Gizmos.DrawWireSphere(transform.position, blackboard.enemy.detectionRadius);
        }

        public void DrawAttackRadius()
        {
            Gizmos.color = blackboard.enemy.attackGizmoColour;
            Gizmos.DrawWireSphere(transform.position, blackboard.enemy.attackRadius);
        }

        public void Arrived()
        {
            (CurrentState as IPatrol)?.Arrived();
        }

        public void Die()
        {
            ChangeState(EnemyState.Death);
        }

        private void Awake()
        {
            States[EnemyState.Idle] = new IdleState(this, blackboard);
            States[EnemyState.Patrol] = new PatrolState(this, blackboard);
            States[EnemyState.Chase] = new ChaseState(this, blackboard);
            States[EnemyState.Attack] = new AttackState(this, blackboard);
            States[EnemyState.Death] = new DeathState(this, blackboard);
        }

        protected override EnemyState InitialState => initialState;
    }
}