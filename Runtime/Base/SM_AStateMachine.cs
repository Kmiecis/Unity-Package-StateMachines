using System;
using System.Collections.Generic;

namespace Common.StateMachines
{
    /// <summary>
    /// Base <see cref="SM_IStateMachine"/> implementation
    /// </summary>
    public abstract class SM_AStateMachine : SM_IStateMachine
    {
        protected readonly Dictionary<Type, SM_IState> _states = new Dictionary<Type, SM_IState>();

        protected string _name;
        protected SM_IState _state;

        public SM_AStateMachine(string name = null)
        {
            _name = name ?? GetType().Name;
        }

        public void WithState(SM_IState state)
        {
            if (_state == null)
                _state = state;

            _states[state.GetType()] = state;
        }

        public virtual void Execute()
        {
            var newStateType = _state.Execute();

            if (newStateType != null)
            {
                _state = _states[newStateType];
            }
        }

        public override string ToString()
        {
            return _name;
        }
    }

    /// <summary>
    /// <see cref="SM_AStateMachine"/> implementation with build-in context <see cref="T"/> support of any type
    /// </summary>
    public abstract class SM_AStateMachine<T> : SM_AStateMachine
    {
        protected readonly T _context;

        public SM_AStateMachine(T context, string name = null) :
            base(name)
        {
            _context = context;
        }
    }
}
