using System.Collections;
using UnityEngine;

namespace EnterKratos.States
{
    public class IdleState: BaseState<EnemyState>
    {
        private readonly EnemyBlackboard _blackboard;
        private int _patrolPointIndex;
        private readonly Collider[] _colliderBuffer;
        private Coroutine _timerCoroutine;
        private readonly EnemyStateMachine _stateMachine;

        public IdleState(EnemyStateMachine stateMachine, EnemyBlackboard blackboard)
            : base(stateMachine)
        {
            _stateMachine = stateMachine;
            _blackboard = blackboard;
            _colliderBuffer = new Collider[PlayerDetection.BufferSize];
        }

        public override void Enter()
        {
            base.Enter();
            _timerCoroutine = StateMachine.StartCoroutine(Timer());
        }

        public override void Update()
        {
            base.Update();

            var playerInDetectionRadius =
                PlayerDetection.DetectPlayer(StateMachine.transform.position, _blackboard.enemy.detectionRadius,
                    _colliderBuffer, _blackboard.playerDetectionMask);
            if (!playerInDetectionRadius || !_blackboard.PlayerHealthSystem || _blackboard.PlayerHealthSystem.Dead)
            {
                return;
            }

            StateMachine.StopCoroutine(_timerCoroutine);
            StateMachine.ChangeState(EnemyState.Chase);
        }

        public override void OnDrawGizmos()
        {
            base.OnDrawGizmos();
            _stateMachine.DrawDetectionRadius();
        }

        private IEnumerator Timer()
        {
            yield return new WaitForSeconds(_blackboard.enemy.idleWaitTime);
            if (_blackboard.patrolPointProvider.Value.PatrolRouteIsValid())
            {
                StateMachine.ChangeState(EnemyState.Patrol);
            } else StateMachine.StartCoroutine(Timer());
        }
    }
}