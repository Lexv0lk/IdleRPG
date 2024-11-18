using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay.Character
{
    public class BoolAnimationBehaviour : IEntityEnable, IEntityDisable
    {
        private readonly IReactiveValue<bool> _condition;
        private readonly Animator _animator;
        private readonly int _animatorKey;

        public BoolAnimationBehaviour(IReactiveValue<bool> condition, Animator animator, int animatorKey)
        {
            _condition = condition;
            _animator = animator;
            _animatorKey = animatorKey;
        }
        
        public void Enable(IEntity entity)
        {
            OnConditionChanged(_condition.Value);
            _condition.Subscribe(OnConditionChanged);
        }

        public void Disable(IEntity entity)
        {
            _condition.Unsubscribe(OnConditionChanged);
        }
        
        private void OnConditionChanged(bool value)
        {
            _animator.SetBool(_animatorKey, value);
        }
    }
}