using UnityEngine;

namespace EnterKratos.States
{
    public class PatrolState: BaseState<EnemyState>
    {
        private readonly EnemyBlackboard _blackboard;
        private int _targetPatrolPointIndex;
        private int _nextPatrolPointIndex;
        private readonly Collider[] _colliderBuffer;

        public PatrolState(StateMachine<EnemyState> stateMachine, EnemyBlackboard blackboard)
            : base(stateMachine)
        {
            _blackboard = blackboard;
            _colliderBuffer = new Collider[PlayerDetection.BufferSize];
        }

        public override void Enter()
        {
            base.Enter();
            _targetPatrolPointIndex = _nextPatrolPointIndex;
            _blackboard.navMeshAgent.GoToPoint(_blackboard.patrolPoints[_targetPatrolPointIndex].position);

            _nextPatrolPointIndex = _targetPatrolPointIndex != _blackboard.patrolPoints.Length - 1 ?
                _nextPatrolPointIndex + 1 : 0;
        }

        public override void Update()
        {
            base.Update();
            CheckPatrolPoints();

            if (PlayerDetection.DetectPlayer(StateMachine.transform.position, _blackboard.enemy.detectionRadius,
                    _colliderBuffer, _blackboard.playerDetectionMask))
            {
                StateMachine.ChangeState(EnemyState.Attack);
            }
        }

        public override void OnDrawGizmos()
        {
            base.OnDrawGizmos();
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(StateMachine.transform.position, _blackboard.enemy.detectionRadius);
        }

        private void CheckPatrolPoints()
        {
            var distance = Vector3.Distance(StateMachine.transform.position, _blackboard.patrolPoints[_targetPatrolPointIndex].position);

            if (distance <= _blackboard.patrolPointTolerance)
            {
                StateMachine.ChangeState(EnemyState.Idle);
            }
        }
    }
}