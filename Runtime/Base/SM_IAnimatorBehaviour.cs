using UnityEngine;

namespace Common.StateMachines
{
    /// <summary>
    /// Animator State Machine behaviour interface
    /// </summary>
    public interface SM_IAnimatorBehaviour<T>
    {
        void Setup(Animator animator, T context);
        void Enable();
        void Disable();
    }
}
