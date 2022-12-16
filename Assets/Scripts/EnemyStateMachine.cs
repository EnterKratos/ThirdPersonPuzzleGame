using EnterKratos.States;

namespace EnterKratos
{
    public class EnemyStateMachine: StateMachine
    {
        private PatrolState _patrolStateState;
        private AttackState _attackState;

        private void Awake()
        {
            _patrolStateState = new PatrolState(this);
            _attackState = new AttackState(this);
        }

        protected override BaseState GetInitialState()
        {
            return _patrolStateState;
        }

        public void PlayerDetected()
        {
            ChangeState(_attackState);
        }
    }
}