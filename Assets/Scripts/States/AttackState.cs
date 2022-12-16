namespace EnterKratos.States
{
    public class AttackState: BaseState
    {
        private NavMeshAgentFollow _follow;

        public AttackState(EnemyStateMachine stateMachine) : base(nameof(AttackState), stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();
            _follow = StateMachine.GetComponent<NavMeshAgentFollow>();
            _follow.enabled = true;
        }

        public override void Exit()
        {
            base.Exit();
            _follow.enabled = false;
        }
    }
}