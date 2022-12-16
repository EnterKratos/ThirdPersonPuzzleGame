namespace EnterKratos.States
{
    public class BaseState
    {
        public string Name { get; }
        protected readonly StateMachine StateMachine;

        protected BaseState(string name, StateMachine stateMachine)
        {
            StateMachine = stateMachine;
            Name = name;
        }

        public virtual void Enter()
        {
        }

        public virtual void Update()
        {
        }

        public virtual void Exit()
        {
        }
    }
}