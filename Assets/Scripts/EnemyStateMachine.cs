using EnterKratos.States;
using UnityEngine;

namespace EnterKratos
{
    public class EnemyStateMachine: StateMachine<EnemyState>
    {
        [SerializeField]
        private EnemyBlackboard blackboard;

        private void Awake()
        {
            States[EnemyState.Patrol] = new PatrolState(this, blackboard);
            States[EnemyState.Attack] = new AttackState(this, blackboard);
        }

        protected override EnemyState InitialState => EnemyState.Patrol;
    }
}