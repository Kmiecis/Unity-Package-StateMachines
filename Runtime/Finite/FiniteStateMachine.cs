using System;
using System.Collections.Generic;

namespace Common.StateMachines
{
    /// <summary>
    /// Base <see cref="IFiniteStateMachine"/> implementation
    /// </summary>
    public class FiniteStateMachine<T> : IFiniteStateMachine<T>
        where T : class, IFiniteState
    {
        protected readonly Dictionary<Type, T> _states = new Dictionary<Type, T>();

        protected string _name;
        protected T _state;

        public FiniteStateMachine(string name = null)
        {
            _name = name ?? GetType().Name;
        }

        public virtual void Add(T state)
        {
            _states.Add(state.GetType(), state);

            if (_state == null)
            {
                _state = state;
            }
        }

        public virtual void Switch(Type type)
        {
            if (_states.ContainsKey(type))
            {
                var newState = _states[type];

                newState.StartState();

                _state.FinishState();

                _state = newState;
            }
        }

        public virtual void Update()
        {
            _state.UpdateState();
        }

        public override string ToString()
        {
            return _name;
        }
    }
}
