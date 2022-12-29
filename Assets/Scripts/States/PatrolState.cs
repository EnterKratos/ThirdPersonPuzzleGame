﻿using UnityEngine;

namespace EnterKratos.States
{
    public class PatrolState: BaseState<EnemyState>
    {
        private readonly EnemyBlackboard _blackboard;
        private int _targetPatrolPointIndex;
        private int _nextPatrolPointIndex;
        private readonly Collider[] _colliderBuffer;
        private readonly EnemyStateMachine _stateMachine;

        public PatrolState(EnemyStateMachine stateMachine, EnemyBlackboard blackboard)
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