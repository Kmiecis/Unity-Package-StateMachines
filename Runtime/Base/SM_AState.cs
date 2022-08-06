using System;
using System.Collections.Generic;

namespace Common.StateMachines
{
    /// <summary>
    /// Base <see cref="SM_IState"/> implementation
    /// </summary>
    public abstract class SM_AState : SM_IState
    {
        protected readonly List<SM_ITransition> _transitions = new List<SM_ITransition>();

        protected string _name;
        protected bool _active;

        public SM_AState(string name = null)
        {
            _name = name ?? GetType().Name;
        }

        public string Name
        {
            get => _name;
        }

        public bool IsActive
        {
            get => _active;
        }

        public void WithTransition(SM_ITransition transition)
        {
            _transitions.Add(transition);
        }

        public void WithTransition(Type type, Func<bool> validator)
        {
            var transition = new SM_Transition(type, validator);
            WithTransition(transition);
        }

        public void WithTransition<T>(Func<bool> validator)
            where T : SM_IState
        {
            var transition = new SM_Transition<T>(validator);
            WithTransition(transition);
        }

        public Type Execute()
        {
            if (!_active)
            {
                OnStart();
                _active = true;
            }

            var result = OnExecute();

            if (
                _active &&
                result != null
            )
            {
                OnFinish();
                _active = false;
            }

            return result;
        }

        protected virtual Type CheckTransitions()
        {
            foreach (var transition in _transitions)
            {
                if (transition.Validator())
                {
                    return transition.Target;
                }
            }
            return null;
        }

        protected virtual void OnStart()
        {
        }

        protected virtual Type OnExecute()
        {
            return CheckTransitions();
        }

        protected virtual void OnFinish()
        {
        }

        public override string ToString()
        {
            return _name;
        }
    }

    /// <summary>
    /// <see cref="SM_AState"/> implementation with build-in context <see cref="T"/> support of any type
    /// </summary>
    public abstract class SM_AState<T> : SM_AState
    {
        protected readonly T _context;

        public SM_AState(T context, string name = null) :
            base(name)
        {
            _context = context;
        }
    }
}
