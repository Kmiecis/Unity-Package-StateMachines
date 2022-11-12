using System;
using System.Collections.Generic;

namespace Common.StateMachines
{
    /// <summary>
    /// Hierarchical State Machine interface
    /// </summary>
    public interface IHierarchicalStateMachine<T>
        where T : IHierarchicalState
    {
        public IEnumerator<T> Set<U>()
            where U : T
        {
            return Set(typeof(U));
        }

        /// <summary>
        /// Order state machine to push new state to stack
        /// </summary>
        void Push(T state);

        /// <summary>
        /// Order state machine to pop current state from stack
        /// </summary>
        T Pop();

        /// <summary>
        /// Order state machine to pop states until one of type is found
        /// </summary>
        IEnumerator<T> Set(Type type);

        /// <summary>
        /// Called every time a state machine is updated
        /// </summary>
        void Update();
    }

    /// <summary>
    /// Concrete Hierarchical State Machine interface
    /// </summary>
    public interface IHierarchicalStateMachine : IHierarchicalStateMachine<IHierarchicalState>
    {
    }
}
