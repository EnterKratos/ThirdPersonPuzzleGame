using System.Collections;
using UnityEngine;

namespace EnterKratos.StateMachines.States
{
    public class ChaseState: BaseState<EnemyState>
    {
        private readonly EnemyBlackboard _blackboard;
        private readonly Collider[] _colliderBuffer;
        private readonly EnemyStateMachine _stateMachine;
        private Coroutine _chaseTimer;
        private float _backupStoppingDistance;

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
            _backupStoppingDistance = _blackboard.navMeshAgent.stoppingDistance;
            _blackboard.navMeshAgent.stoppingDistance = _blackboard.enemy.chaseStoppingDistance;
        }

        public override void Update()
        {
            base.Update();
            GoToPlayer();

            var position = _stateMachine.transform.position;
            var enemy = _blackboard.enemy;
            var detectionMask = _blackboard.playerDetectionMask;

            if (PlayerDetection.DetectPlayer(position, enemy.detectionRadius, _colliderBuffer, detectionMask))
            {
                if (_chaseTimer != null)
                {
                    StateMachine.StopCoroutine(_chaseTimer);
                    _chaseTimer = null;
                }
            }
            else
            {
                if (_chaseTimer != null)
                {
                    return;
                }

                _chaseTimer = StateMachine.StartCoroutine(ChaseTimer());
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
            _blackboard.navMeshAgent.stoppingDistance = _backupStoppingDistance;
        }

        public override void OnDrawGizmos()
        {
            base.OnDrawGizmos();
            _stateMachine.DrawDetectionRadius();
            _stateMachine.DrawAttackRadius();
        }

        private IEnumerator ChaseTimer()
        {
            yield return new WaitForSeconds(_blackboard.enemy.chaseTimeout);
            _chaseTimer = null;

            _stateMachine.ChangeState(EnemyState.Patrol);
        }

        private void GoToPlayer()
        {
            _blackboard.navMeshAgent.destination = _blackboard.player.position;
        }
    }
}