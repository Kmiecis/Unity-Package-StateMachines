using System;

namespace Common.StateMachines
{
    /// <summary>
    /// Default <see cref="SM_ATransition"/> implementation
    /// </summary>
    public sealed class SM_Transition : SM_ATransition
    {
        public SM_Transition(Type target, Func<bool> validator) :
            base(target, validator)
        {
        }
    }

    /// <summary>
    /// Default <see cref="SM_ATransition{T}"/> implementation
    /// </summary>
    public sealed class SM_Transition<T> : SM_ATransition<T>
        where T : SM_IState
    {
        public SM_Transition(Func<bool> validator) :
            base(validator)
        {
        }
    }
}
