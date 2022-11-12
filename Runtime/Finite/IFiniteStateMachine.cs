using System;

namespace Common.StateMachines
{
    /// <summary>
    /// Finite State Machine interface
    /// </summary>
    public interface IFiniteStateMachine<T>
        where T : IFiniteState
    {
        public void Switch<U>()
            where U : T
        {
            Switch(typeof(U));
        }

        /// <summary>
        /// Order state machine to add state
        /// </summary>
        void Add(T state);

        /// <summary>
        /// Order state machine state switch by state type
        /// </summary>
        void Switch(Type type);

        /// <summary>
        /// Called every time a state machine is updated
        /// </summary>
        void Update();
    }
}
