﻿using EnterKratos.Animation;
using EnterKratos.Extensions;
using UnityEngine;

namespace EnterKratos.StateMachines.States
{
    public class AttackState: BaseState<EnemyState>
    {
        private readonly EnemyBlackboard _blackboard;
        private readonly Collider[] _colliderBuffer;
        private bool _playerInAttackRadius;
        private readonly EnemyStateMachine _stateMachine;
        private float _backupStoppingDistance;

        public AttackState(EnemyStateMachine stateMachine, EnemyBlackboard blackboard)
            : base(stateMachine)
        {
            _stateMachine = stateMachine;
            _blackboard = blackboard;
            _colliderBuffer = new Collider[PlayerDetection.BufferSize];
        }

        public override void Enter()
        {
            base.Enter();
            _blackboard.animator.SetTrigger(EnemyBlackboard.AttackParam);
            _backupStoppingDistance = _blackboard.navMeshAgent.stoppingDistance;
            _blackboard.navMeshAgent.stoppingDistance = _blackboard.enemy.attackStoppingDistance;
        }

        public override void Update()
        {
            base.Update();
            var transform = StateMachine.transform;
            transform.RotateTowards(_blackboard.player, _blackboard.enemy.rotationSpeed);

            var position = transform.position;
            var enemy = _blackboard.enemy;
            var detectionMask = _blackboard.playerDetectionMask;

            var playerInDetectionRadius =
                PlayerDetection.DetectPlayer(position, enemy.detectionRadius, _colliderBuffer, detectionMask);
            if (!playerInDetectionRadius || _blackboard.PlayerHealthSystem.Dead)
            {
                StateMachine.ChangeState(EnemyState.Patrol);
                return;
            }

            _playerInAttackRadius = PlayerDetection.DetectPlayer(position, enemy.attackRadius, _colliderBuffer, detectionMask);
            if (_playerInAttackRadius)
            {
                _blackboard.animator.SetTrigger(EnemyBlackboard.AttackParam);
            }
            else
            {
                StateMachine.ChangeState(EnemyState.Chase);
            }
        }

        public override void Exit()
        {
            base.Exit();
            _blackboard.animator.SetBool(EnemyBlackboard.AttackParam, false);
            _blackboard.navMeshAgent.stoppingDistance = _backupStoppingDistance;
        }

        public override void HandleEvent(int eventType)
        {
            base.HandleEvent(eventType);
            switch ((EnemyAnimationEvents)eventType)
            {
                case EnemyAnimationEvents.Attack:
                {
                    if (_playerInAttackRadius)
                    {
                        _blackboard.PlayerHealthSystem.Attack(_blackboard.enemy.attackDamage);
                    }
                    break;
                }
                default:
                    Debug.LogWarning($"Unhandled AnimationEvent type {(EnemyAnimationEvents)eventType}");
                    break;
            }
        }

        public override void OnDrawGizmos()
        {
            base.OnDrawGizmos();
            _stateMachine.DrawDetectionRadius();
            _stateMachine.DrawAttackRadius();
        }
    }
}