using System;

namespace Common.StateMachines
{
    /// <summary>
    /// Base <see cref="SM_ITransition"/> implementation
    /// </summary>
    public abstract class SM_ATransition : SM_ITransition
    {
        protected readonly Type _target;
        protected readonly Func<bool> _validator;

        public SM_ATransition(Type target, Func<bool> validator)
        {
            _target = target;
            _validator = validator;
        }

        public Type Target
        {
            get => _target;
        }

        public Func<bool> Validator
        {
            get => _validator;
        }
    }

    /// <summary>
    /// Templated <see cref="SM_ATransition"/> implementation
    /// </summary>
    public abstract class SM_ATransition<T> : SM_ATransition
        where T : SM_IState
    {
        public SM_ATransition(Func<bool> validator) :
            base(typeof(T), validator)
        {
        }
    }
}
