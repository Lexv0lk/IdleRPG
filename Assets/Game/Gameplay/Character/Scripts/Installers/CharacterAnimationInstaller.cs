using System;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay.Character
{
    [Serializable]
    public class CharacterAnimationInstaller : IEntityInstaller
    {
        [SerializeField] private Animator _animator;

        [Header("Animation Keys")] 
        [SerializeField] private string _moveBoolean = "IsMoving";
        
        public void Install(IEntity entity)
        {
            BoolAnimationBehaviour movingAnimationBehavior = new BoolAnimationBehaviour(entity.GetIsMoving(), _animator, Animator.StringToHash(_moveBoolean));
            entity.AddBehaviour(movingAnimationBehavior);
        }
    }
}