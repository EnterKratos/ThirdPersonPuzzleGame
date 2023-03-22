using EnterKratos.Extensions;
using EnterKratos.Patrol;
using UnityEngine;

namespace EnterKratos.StateMachines.States
{
    public class PatrolState: BaseState<EnemyState>, IPatrol
    {
        private readonly EnemyBlackboard _blackboard;
        private readonly Collider[] _colliderBuffer;
        private readonly EnemyStateMachine _stateMachine;
        private readonly PatrolManager _patrolManager;
        private float _backupStoppingDistance;

        public PatrolPoint TargetPatrolPoint { get; private set; }

        public PatrolState(EnemyStateMachine stateMachine, EnemyBlackboard blackboard)
            : base(stateMachine)
        {
            _stateMachine = stateMachine;
            _blackboard = blackboard;
            _colliderBuffer = new Collider[PlayerDetection.BufferSize];
            _patrolManager = new PatrolManager(_blackboard.patrolPointProvider.Value);
        }

        public override void Enter()
        {
            base.Enter();
            _blackboard.animator.SetBool(EnemyBlackboard.MovingParam, true);

            TargetPatrolPoint = _patrolManager.Next();
            _blackboard.navMeshAgent.GoToPoint(TargetPatrolPoint.transform.position);
            _backupStoppingDistance = _blackboard.navMeshAgent.stoppingDistance;
            _blackboard.navMeshAgent.stoppingDistance = _blackboard.enemy.patrolStoppingDistance;
        }

        public override void Update()
        {
            base.Update();

            if (_blackboard.PlayerHealthSystem.Dead)
            {
                return;
            }

            if (PlayerDetection.DetectPlayer(StateMachine.transform.position, _blackboard.enemy.detectionRadius,
                    _colliderBuffer, _blackboard.playerDetectionMask))
            {
                StateMachine.ChangeState(EnemyState.Chase);
            }
        }

        public override void Exit()
        {
            base.Exit();
            _blackboard.animator.SetBool(EnemyBlackboard.MovingParam, false);
            _blackboard.navMeshAgent.stoppingDistance = _backupStoppingDistance;
        }

        public override void OnDrawGizmos()
        {
            base.OnDrawGizmos();
            _stateMachine.DrawDetectionRadius();
        }

        public void Arrived()
        {
            StateMachine.ChangeState(EnemyState.Idle);
        }
    }
}