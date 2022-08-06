using UnityEngine;

namespace Common.StateMachines
{
    /// <summary>
    /// Base <see cref="SM_IAnimatorBehaviour{T}"/> implementation
    /// </summary>
    public abstract class SM_AAnimatorBehaviour<T> : StateMachineBehaviour, SM_IAnimatorBehaviour<T>
    {
        protected Animator _animator;
        protected AnimatorStateInfo _stateInfo;
        protected int _layerIndex;

        protected T _context;

        private bool _active = false;
        private bool _enabled = false;

        public bool IsActive
        {
            get => _active;
        }

        public bool IsEnabled
        {
            get => _enabled;
        }

        private void UpdateInternalState(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _animator = animator;
            _stateInfo = stateInfo;
            _layerIndex = layerIndex;
        }

        protected virtual void OnSetup()
        {
        }

        protected virtual void OnEnter()
        {
        }

        protected virtual void OnUpdate()
        {
        }

        protected virtual void OnExit()
        {
        }

        public void Setup(Animator animator, T context)
        {
            _animator = animator;
            _context = context;

            OnSetup();
        }

        public void Enable()
        {
            if (_enabled)
                return;
            _enabled = true;
        }

        public void Disable()
        {
            if (!_enabled)
                return;
            _enabled = false;

            if (_active)
            {
                OnExit();
                _active = false;
            }
        }

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (_active || !_enabled)
                return;
            _active = true;

            UpdateInternalState(animator, stateInfo, layerIndex);

            OnEnter();
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (!_active || !_enabled)
                return;

            UpdateInternalState(animator, stateInfo, layerIndex);

            OnUpdate();
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (!_active || !_enabled)
                return;
            _active = false;

            UpdateInternalState(animator, stateInfo, layerIndex);

            OnExit();
        }

        protected virtual void OnDestroy()
        {
            Disable();
        }
    }
}
