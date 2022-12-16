using EnterKratos.States;
using UnityEngine;

namespace EnterKratos
{
    public class StateMachine: MonoBehaviour
    {
        public string currentStateName;
        private BaseState _currentState;

        private void Start()
        {
            _currentState = GetInitialState();
            ChangeState(_currentState);
        }

        protected void Update()
        {
            _currentState?.Update();
        }

        protected void ChangeState(BaseState newState)
        {
            _currentState.Exit();

            _currentState = newState;
            currentStateName = _currentState.Name;

            _currentState.Enter();
        }

        protected virtual BaseState GetInitialState()
        {
            return null;
        }
    }
}