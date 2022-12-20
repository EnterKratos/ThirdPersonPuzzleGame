using System;

namespace EnterKratos.States
{
    public class BaseState<T> where T : Enum
    {
        protected readonly StateMachine<T> StateMachine;

        protected BaseState(StateMachine<T> stateMachine)
        {
            StateMachine = stateMachine;
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

        public virtual void OnDrawGizmos()
        {
        }
    }
}