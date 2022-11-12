namespace Common.StateMachines
{
    /// <summary>
    /// Base <see cref="IHierarchicalState"/> implementation
    /// </summary>
    public class HierarchicalState : IHierarchicalState
    {
        protected readonly IHierarchicalStateMachine<HierarchicalState> _stateMachine;

        public HierarchicalState(IHierarchicalStateMachine<HierarchicalState> stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public virtual void HideState()
        {
        }

        public virtual void ShowState()
        {
        }

        public virtual void UpdateState()
        {
        }
    }
}
