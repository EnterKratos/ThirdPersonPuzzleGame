using System.Linq;
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

            var position = StateMachine.transform.position;
            var enemy = _blackboard.enemy;
            var detectionMask = _blackboard.playerDetectionMask;

            if (!PlayerDetection.DetectPlayer(position, enemy.detectionRadius, _colliderBuffer, detectionMask))
            {
                StateMachine.ChangeState(EnemyState.Patrol);
            }

            if (PlayerDetection.DetectPlayer(position, enemy.attackRadius, _colliderBuffer, detectionMask))
            {
                _colliderBuffer.First().GetComponent<HealthSystem>().Attack(enemy.attackDamage);
            }
        }

        public override void OnDrawGizmos()
        {
            base.OnDrawGizmos();
            var position = StateMachine.transform.position;

            Gizmos.color = _blackboard.enemy.detectionGizmoColour;
            Gizmos.DrawWireSphere(position, _blackboard.enemy.detectionRadius);

            Gizmos.color = _blackboard.enemy.attackGizmoColour;
            Gizmos.DrawWireSphere(position, _blackboard.enemy.attackRadius);
        }

        private void GoToPlayer()
        {
            _blackboard.navMeshAgent.destination = _blackboard.player.position;
        }
    }
}