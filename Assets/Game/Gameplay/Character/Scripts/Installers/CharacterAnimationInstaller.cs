using System;
using Atomic.Entities;
using Game.GameEngine.Animations;
using Game.GameEngine.Atomic.Behaviours;
using UnityEngine;

namespace Game.Gameplay.Character
{
    [Serializable]
    public class CharacterAnimationInstaller : IEntityInstaller
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private AnimatorDispatcher _animatorDispatcher;

        [Header("Animation Keys")] 
        [SerializeField] private string _moveBoolean = "IsMoving";
        [SerializeField] private string _attackTrigger = "Attack";
        [SerializeField] private string _attackStopTrigger = "StopAttack";
        [SerializeField] private string _dieBoolean = "Die";

        [Header("Animation Events")] 
        [SerializeField] private string _attackedEvent = "Attacked";
        [SerializeField] private string _attackEndEvent = "AttackEnd";
        
        public void Install(IEntity entity)
        {
            BoolAnimationBehaviour movingAnimationBehavior = new BoolAnimationBehaviour(entity.GetIsMoving(), _animator, Animator.StringToHash(_moveBoolean));
            BoolAnimationBehaviour deathAnimationBehaviour =
                new BoolAnimationBehaviour(entity.GetIsDead(), _animator, Animator.StringToHash(_dieBoolean));
            AttackAnimationBehaviour attackAnimationBehaviour = new AttackAnimationBehaviour(_animator,
                _animatorDispatcher, _attackTrigger, _attackStopTrigger, _attackedEvent);
            
            entity.AddBehaviour(movingAnimationBehavior);
            entity.AddBehaviour(attackAnimationBehaviour);
            entity.AddBehaviour(deathAnimationBehaviour);
        }
    }
}