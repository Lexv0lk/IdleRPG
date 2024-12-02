using Atomic.Entities;
using Sirenix.Serialization;

namespace Game.Gameplay.Enemy
{
    public class EnemyInstallerBase : SceneEntityInstallerBase
    {
        [OdinSerialize] private EnemyCoreInstaller _coreInstaller;
        [OdinSerialize] private EnemyMovementInstaller _movementInstaller;
        [OdinSerialize] private EnemyPatrolInstaller _patrolInstaller;
        
        public override void Install(IEntity entity)
        {
            _coreInstaller.Install(entity);
            _movementInstaller.Install(entity);
            _patrolInstaller.Install(entity);
        }
    }
}