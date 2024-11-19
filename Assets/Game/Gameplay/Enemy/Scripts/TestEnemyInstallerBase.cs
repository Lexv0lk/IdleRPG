using Atomic.Elements;
using Atomic.Entities;

namespace Game.Gameplay.Enemy
{
    public class TestEnemyInstallerBase : SceneEntityInstallerBase
    {
        public override void Install(IEntity entity)
        {
            entity.AddHealth(new ReactiveVariable<int>(1000));
            entity.AddTransform(transform);
        }
    }
}