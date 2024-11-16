using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay.Character
{
    public class CharacterInstallerBase : SceneEntityInstallerBase
    {
        [SerializeField] private CharacterMovementInstaller _movementInstaller;
        [SerializeField] private CharacterCoreInstaller _coreInstaller;
        
        public override void Install(IEntity entity)
        {
            _coreInstaller.Install(entity);
            _movementInstaller.Install(entity);
        }
    }
}