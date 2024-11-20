using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay.Enemy
{
    public class EnemyInstallerBase : SceneEntityInstallerBase
    {
        [SerializeField] private EnemyMovementInstaller _movementInstaller;
        [SerializeField] private EnemyPatrolInstaller _patrolInstaller;
        
        public override void Install(IEntity entity)
        {
            _movementInstaller.Install(entity);
            _patrolInstaller.Install(entity);
        }
    }
}