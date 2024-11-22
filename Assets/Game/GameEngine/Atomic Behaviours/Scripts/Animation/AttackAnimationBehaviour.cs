using Atomic.Elements;
using Atomic.Entities;
using Game.GameEngine.Animations;
using UnityEngine;

namespace Game.GameEngine.Atomic.Behaviours
{
    public class AttackAnimationBehaviour : IEntityInit, IEntityEnable, IEntityDisable
    {
        private readonly AnimatorDispatcher _dispatcher;
        private readonly string _attackTriggerName;
        private readonly string _stopAttackTriggerName;
        private readonly string _attackEventName;
        private readonly Animator _animator;

        private IAction _attackAction;
        private IPredicate _canAttack;
        private IEvent _attackRequest;
        private IEvent _attackStopAction;
        private bool _isInAttackAnimation;
        
        public AttackAnimationBehaviour(Animator animator,
            AnimatorDispatcher dispatcher, string attackTriggerName, string stopAttackTriggerName, string attackEventName)
        {
            _dispatcher = dispatcher;
            _attackTriggerName = attackTriggerName;
            _stopAttackTriggerName = stopAttackTriggerName;
            _attackEventName = attackEventName;
            _animator = animator;
        }
        
        public void Init(IEntity entity)
        {
            _attackAction = entity.GetAttackAction();
            _attackRequest = entity.GetAttackRequest();
            _canAttack = entity.GetCanAttack();
            _attackStopAction = entity.GetAttackStopAction();
        }
        
        public void Enable(IEntity entity)
        {
            _attackRequest.OnEvent += OnAttackRequested;
            _attackStopAction.OnEvent += OnAttackStopAction;
            _dispatcher.SubscribeOnEvent(_attackEventName, OnAttackedAnimation);
            _isInAttackAnimation = false;
        }

        public void Disable(IEntity entity)
        {
            _attackRequest.OnEvent -= OnAttackRequested;
            _attackStopAction.OnEvent -= OnAttackStopAction;
            _dispatcher.UnsubscribeOnEvent(_attackEventName, OnAttackedAnimation);
        }
        
        private void OnAttackRequested()
        {
            if (_canAttack.Invoke() && _isInAttackAnimation == false)
            {
                _animator.ResetTrigger(_stopAttackTriggerName);
                _animator.SetTrigger(_attackTriggerName);
                _isInAttackAnimation = true;
            }
        }

        private void OnAttackStopAction()
        {
            _animator.SetTrigger(_stopAttackTriggerName);
            _isInAttackAnimation = false;
        }
        
        private void OnAttackedAnimation()
        {
            _attackAction.Invoke();
            _isInAttackAnimation = false;
        }
    }
}