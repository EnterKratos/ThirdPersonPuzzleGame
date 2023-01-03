using UnityEngine;

namespace EnterKratos.States
{
    public class PatrolState: BaseState<EnemyState>, IPatrol
    {
        private readonly EnemyBlackboard _blackboard;
        private readonly Collider[] _colliderBuffer;
        private readonly EnemyStateMachine _stateMachine;
        private readonly PatrolManager _patrolManager;

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
        }

        public override void Update()
        {
            base.Update();

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