using UnityEngine;

namespace EnterKratos.States
{
    public class ChaseState: BaseState<EnemyState>
    {
        private readonly EnemyBlackboard _blackboard;
        private readonly Collider[] _colliderBuffer;
        private readonly EnemyStateMachine _stateMachine;

        public ChaseState(EnemyStateMachine stateMachine, EnemyBlackboard blackboard)
            : base(stateMachine)
        {
            _stateMachine = stateMachine;
            _blackboard = blackboard;
            _colliderBuffer = new Collider[PlayerDetection.BufferSize];
        }

        public override void Enter()
        {
            base.Enter();
            _blackboard.animator.SetBool(EnemyBlackboard.MovingParam, true);
        }

        public override void Update()
        {
            base.Update();
            GoToPlayer();

            var position = _stateMachine.transform.position;
            var enemy = _blackboard.enemy;
            var detectionMask = _blackboard.playerDetectionMask;

            if (!PlayerDetection.DetectPlayer(position, enemy.detectionRadius, _colliderBuffer, detectionMask))
            {
                _stateMachine.ChangeState(EnemyState.Patrol);
            }

            if (PlayerDetection.DetectPlayer(position, enemy.attackRadius, _colliderBuffer, detectionMask))
            {
                _stateMachine.ChangeState(EnemyState.Attack);
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
            _stateMachine.DrawAttackRadius();
        }

        private void GoToPlayer()
        {
            _blackboard.navMeshAgent.destination = _blackboard.player.position;
        }
    }
}