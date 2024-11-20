using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay.Hero
{
    public class HeroInstallerBase : SceneEntityInstallerBase
    {
        [SerializeField] private HeroMovementInstaller _movementInstaller;
        [SerializeField] private HeroVisualInstaller _visualInstaller;
        
        public override void Install(IEntity entity)
        {
            _movementInstaller.Install(entity);
            _visualInstaller.Install(entity);
        }
    }
}