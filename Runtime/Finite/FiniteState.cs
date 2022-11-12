namespace Common.StateMachines
{
    /// <summary>
    /// Base <see cref="IFiniteState"/> implementation
    /// </summary>
    public class FiniteState : IFiniteState
    {
        protected readonly IFiniteStateMachine<FiniteState> _machine;

        private string _name;

        public FiniteState(IFiniteStateMachine<FiniteState> machine, string name = null)
        {
            _machine = machine;
            _name = name ?? GetType().Name;

            machine.Add(this);
        }

        public virtual void StartState()
        {
        }

        public virtual void UpdateState()
        {
        }

        public virtual void FinishState()
        {
        }

        public override string ToString()
        {
            return _name;
        }
    }
}
