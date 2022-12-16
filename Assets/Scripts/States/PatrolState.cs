namespace EnterKratos.States
{
    public class PatrolState: BaseState
    {
        private Patrol _patrol;

        public PatrolState(EnemyStateMachine stateMachine) : base(nameof(PatrolState), stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();
            _patrol = StateMachine.GetComponent<Patrol>();
            _patrol.enabled = true;
        }

        public override void Exit()
        {
            base.Exit();
            if (_patrol == null)
            {
                return;
            }
            _patrol.enabled = false;
        }
    }
}