using UnityEngine;

namespace EnterKratos.States
{
    public class PatrolState: BaseState<EnemyState>
    {
        private readonly EnemyBlackboard _blackboard;
        private int _patrolPointIndex;
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
            GoToPoint();
        }

        public override void Update()
        {
            base.Update();
            CheckPatrolPoints();

            if (PlayerDetection.DetectPlayer(StateMachine.transform.position, _blackboard.enemy.detectionRadius,
                    _colliderBuffer, _blackboard.layerMask))
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
            var distance = Vector3.Distance(StateMachine.transform.position, _blackboard.patrolPoints[_patrolPointIndex].position);

            if (distance > _blackboard.patrolPointTolerance)
            {
                return;
            }

            if (_patrolPointIndex == _blackboard.patrolPoints.Length - 1)
            {
                _patrolPointIndex = 0;
            }
            else
            {
                _patrolPointIndex++;
            }

            GoToPoint();
        }

        private void GoToPoint()
        {
            _blackboard.navMeshAgent.destination = _blackboard.patrolPoints[_patrolPointIndex].position;
        }
    }
}