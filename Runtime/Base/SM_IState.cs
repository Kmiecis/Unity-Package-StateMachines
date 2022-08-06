using System;

namespace Common.StateMachines
{
    /// <summary>
    /// State Machine state interface
    /// </summary>
    public interface SM_IState
    {
        /// <summary>
        /// Called every time a state is executed. Returns type of state to switch to.
        /// </summary>
        Type Execute();
    }
}
