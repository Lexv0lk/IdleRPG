using Atomic.Entities;
using Game.GameEngine.LocationServices;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.Character
{
    public class CharacterInstallerBase : SceneEntityInstallerBase
    {
        [SerializeField] private CharacterCoreInstaller _coreInstaller;
        [SerializeField] private CharacterMovementInstaller _movementInstaller;
        [SerializeField] private CharacterCombatInstaller _combatInstaller;
        [SerializeField] private CharacterAnimationInstaller _animationInstaller;
        [SerializeField] private CharacterVisualInstaller _visualInstaller;

        private ConfigService _configService;
        
        [Inject]
        private void Construct(ConfigService configService)
        {
            _configService = configService;
        }
        
        public override void Install(IEntity entity)
        {
            _visualInstaller.Construct(_configService);
            
            _coreInstaller.Install(entity);
            _movementInstaller.Install(entity);
            _combatInstaller.Install(entity);
            _animationInstaller.Install(entity);
            _visualInstaller.Install(entity);
        }
    }
}