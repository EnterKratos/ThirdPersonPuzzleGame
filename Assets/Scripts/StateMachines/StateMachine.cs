using System;
using System.Collections.Generic;
using EnterKratos.StateMachines.States;
using UnityEngine;

namespace EnterKratos.StateMachines
{
    public class StateMachine<T>: MonoBehaviour where T: Enum
    {
        protected virtual T InitialState => default;
        protected readonly Dictionary<T, BaseState<T>> States = new();
        private T _currentState;
        protected BaseState<T> CurrentState => States.ContainsKey(_currentState) ? States[_currentState] : null;

        public void ChangeState(T state)
        {
            CurrentState?.Exit();

            _currentState = state;

            CurrentState?.Enter();
        }

        private void Start()
        {
            _currentState = InitialState;
            ChangeState(_currentState);
        }

        private void Update()
        {
            CurrentState?.Update();
        }

        private void OnDrawGizmos()
        {
            CurrentState?.OnDrawGizmos();
        }
    }
}