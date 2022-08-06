namespace Common.StateMachines
{
    /// <summary>
    /// Default <see cref="SM_AState"/> implementation. Is empty.
    /// </summary>
    public sealed class SM_State : SM_AState
    {
        public SM_State(string name = "State") :
            base(name)
        {
        }

        public new SM_State WithTransition(SM_ITransition transition)
        {
            base.WithTransition(transition);
            return this;
        }
    }
}
