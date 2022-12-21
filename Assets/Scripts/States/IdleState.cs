using System.Collections;
using UnityEngine;

namespace EnterKratos.States
{
    public class IdleState: BaseState<EnemyState>
    {
        private readonly EnemyBlackboard _blackboard;
        private int _patrolPointIndex;

        public IdleState(StateMachine<EnemyState> stateMachine, EnemyBlackboard blackboard)
            : base(stateMachine)
        {
            _blackboard = blackboard;
        }

        public override void Enter()
        {
            base.Enter();
            StateMachine.StartCoroutine(Timer());
        }

        private IEnumerator Timer()
        {
            yield return new WaitForSeconds(_blackboard.idleWaitTime);
            StateMachine.ChangeState(EnemyState.Patrol);
        }
    }
}