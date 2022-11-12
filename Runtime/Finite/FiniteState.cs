namespace Common.StateMachines
{
    /// <summary>
    /// Base <see cref="IFiniteState"/> implementation
    /// </summary>
    public class FiniteState : IFiniteState
    {
        protected readonly IFiniteStateMachine<FiniteState> _stateMachine;

        public FiniteState(IFiniteStateMachine<FiniteState> stateMachine)
        {
            _stateMachine = stateMachine;
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
    }
}
