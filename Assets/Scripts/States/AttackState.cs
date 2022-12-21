using UnityEngine;

namespace EnterKratos.States
{
    public class AttackState: BaseState<EnemyState>
    {
        private readonly EnemyBlackboard _blackboard;
        private readonly Collider[] _colliderBuffer;

        public AttackState(StateMachine<EnemyState> stateMachine, EnemyBlackboard blackboard)
            : base(stateMachine)
        {
            _blackboard = blackboard;
            _colliderBuffer = new Collider[PlayerDetection.BufferSize];
        }

        public override void Update()
        {
            base.Update();
            GoToPlayer();

            if (!PlayerDetection.DetectPlayer(StateMachine.transform.position, _blackboard.enemy.detectionRadius,
                    _colliderBuffer, _blackboard.playerDetectionMask))
            {
                StateMachine.ChangeState(EnemyState.Patrol);
            }
        }

        public override void OnDrawGizmos()
        {
            base.OnDrawGizmos();
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(StateMachine.transform.position, _blackboard.enemy.detectionRadius);
        }

        private void GoToPlayer()
        {
            _blackboard.navMeshAgent.destination = _blackboard.player.position;
        }
    }
}