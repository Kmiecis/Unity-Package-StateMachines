using System;
using System.Collections.Generic;

namespace Common.StateMachines
{
    public class HierarchicalStateMachine<T> : IHierarchicalStateMachine<T>
        where T : class, IHierarchicalState
    {
        protected Stack<T> _states = new Stack<T>();

        public void Push(T state)
        {
            if (_states.TryPeek(out var current))
            {
                current.HideState();
            }

            _states.Push(state);
        }

        public T Pop()
        {
            if (_states.TryPop(out var current))
            {
                if (_states.TryPeek(out var next))
                {
                    next.ShowState();
                }

                return current;
            }

            return null;
        }

        public IEnumerator<T> Set(Type type)
        {
            while (
                _states.TryPeek(out var current) &&
                current.GetType() != type
            )
            {
                yield return Pop();
            }
        }

        public void Update()
        {
            if (_states.TryPeek(out var current))
            {
                current.UpdateState();
            }
        }
    }

    /// <summary>
    /// Concrete <see cref="HierarchicalStateMachine{T}"/> of <see cref="IHierarchicalState"/> implementation
    /// </summary>
    public class HierarchicalStateMachine : HierarchicalStateMachine<IHierarchicalState>, IHierarchicalStateMachine
    {
    }
}
