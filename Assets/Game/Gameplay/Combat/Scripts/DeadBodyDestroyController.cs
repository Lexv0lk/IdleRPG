using Atomic.Entities;
using Cysharp.Threading.Tasks;
using Game.GameEngine.LocationServices;
using Game.GameEngine.Pools;
using Game.Gameplay.GameStates;

namespace Game.Gameplay.Combat
{
    public class DeadBodyDestroyController : IGameStartListener, IGameFinishListener
    {
        private readonly ComplexEntityPool _enemiesPool;
        private readonly EnemyKillObserver _killObserver;
        private readonly IEntityWorld _entityWorld;
        private readonly DeadBodyRemoveConfig _config;

        public DeadBodyDestroyController(ComplexEntityPool enemiesPool, 
            EnemyKillObserver killObserver, IEntityWorld entityWorld, ConfigService configService)
        {
            _enemiesPool = enemiesPool;
            _killObserver = killObserver;
            _entityWorld = entityWorld;
            _config = configService.GetConfig<DeadBodyRemoveConfig>();
        }
        
        public void OnStart()
        {
            _killObserver.Killed += OnKilled;
        }

        private void OnKilled(IEntity enemy)
        {
            DestroyEnemyAsync(enemy);
        }

        private async UniTask DestroyEnemyAsync(IEntity enemy)
        {
            await UniTask.Delay((int)(_config.StartDelay * 1000));
            _entityWorld.DelEntity(enemy);

            // enemy.GetHealth().Value = enemy.GetMaxHealth().Value;
            // enemy.GetIsDead().Value = false;
            
            var enemyObject = enemy.GetTransform().gameObject;
            enemy.Dispose();
            _enemiesPool.Release(enemyObject.GetComponent<SceneEntity>());
        }

        public void OnFinish()
        {
            _killObserver.Killed -= OnKilled;
        }
    }
}