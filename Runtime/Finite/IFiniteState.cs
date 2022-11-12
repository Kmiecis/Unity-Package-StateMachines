namespace Common.StateMachines
{
    /// <summary>
    /// Finite State Machine state interface
    /// </summary>
    public interface IFiniteState
    {
        /// <summary>
        /// Called once when a state is switched to
        /// </summary>
        void StartState();

        /// <summary>
        /// Called every time a state is updated
        /// </summary>
        void UpdateState();

        /// <summary>
        /// Called once when a state is switched from
        /// </summary>
        void FinishState();
    }
}
