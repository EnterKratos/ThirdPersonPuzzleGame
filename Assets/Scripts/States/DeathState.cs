using System.Collections;
using UnityEngine;

namespace EnterKratos.States
{
    public class DeathState: BaseState<EnemyState>
    {
        private readonly EnemyBlackboard _blackboard;
        private readonly EnemyStateMachine _stateMachine;

        public DeathState(EnemyStateMachine stateMachine, EnemyBlackboard blackboard)
            : base(stateMachine)
        {
            _stateMachine = stateMachine;
            _blackboard = blackboard;
        }

        public override void Enter()
        {
            base.Enter();
            StateMachine.StartCoroutine(Timer());
        }

        private IEnumerator Timer()
        {
            yield return new WaitForSeconds(_blackboard.enemy.deathTimeout);
            _stateMachine.gameObject.SetActive(false);
        }
    }
}