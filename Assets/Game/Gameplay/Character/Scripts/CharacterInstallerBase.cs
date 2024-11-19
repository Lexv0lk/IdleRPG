using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay.Character
{
    public class CharacterInstallerBase : SceneEntityInstallerBase
    {
        [SerializeField] private CharacterCoreInstaller _coreInstaller;
        [SerializeField] private CharacterMovementInstaller _movementInstaller;
        [SerializeField] private CharacterCombatInstaller _combatInstaller;
        [SerializeField] private CharacterAnimationInstaller _animationInstaller;
        
        public override void Install(IEntity entity)
        {
            _coreInstaller.Install(entity);
            _movementInstaller.Install(entity);
            _combatInstaller.Install(entity);
            _animationInstaller.Install(entity);
        }
    }
}