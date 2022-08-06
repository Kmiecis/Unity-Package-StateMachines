namespace Common.StateMachines
{
    /// <summary>
    /// Default <see cref="SM_AStateMachine"/> implementation
    /// </summary>
    public sealed class SM_StateMachine : SM_AStateMachine
    {
        public SM_StateMachine(string name = "State Machine") :
            base(name)
        {
        }

        public new SM_StateMachine WithState(SM_IState state)
        {
            base.WithState(state);
            return this;
        }
    }
}
