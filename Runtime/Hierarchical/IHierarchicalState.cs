namespace Common.StateMachines
{
    /// <summary>
    /// Hierarchical State Machine state interface
    /// </summary>
    public interface IHierarchicalState
    {
        /// <summary>
        /// Called once when a state resurfaces
        /// </summary>
        void ShowState();

        /// <summary>
        /// Called every time a state is updated
        /// </summary>
        void UpdateState();

        /// <summary>
        /// Called once when a state is drown
        /// </summary>
        void HideState();
    }
}
