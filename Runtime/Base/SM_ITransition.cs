using System;

namespace Common.StateMachines
{
    /// <summary>
    /// State Machine transition interface
    /// </summary>
    public interface SM_ITransition
    {
        /// <summary>
        /// Returns state type to switch to
        /// </summary>
        Type Target { get; }

        /// <summary>
        /// Checks whether transition should occur
        /// </summary>
        Func<bool> Validator { get; }
    }
}
