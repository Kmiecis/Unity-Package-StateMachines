namespace Common.StateMachines
{
    /// <summary>
    /// State Machine interface
    /// </summary>
    public interface SM_IStateMachine
    {
        /// <summary>
        /// Called every time a state machine is executed
        /// </summary>
        void Execute();
    }
}
