using System;
using System.Collections.Generic;
using Atomic.Entities;
using Game.Gameplay.Enemy;
using Game.Gameplay.GameStates;

namespace Game.Gameplay.Combat
{
    public class EnemyKillObserver : IGameInitializeListener, IGameFinishListener
    {
        private readonly List<EnemySpawner> _spawners;

        public event Action<IEntity> Killed; 

        public EnemyKillObserver(List<EnemySpawner> spawners)
        {
            _spawners = spawners;
        }
        
        public void OnInitialize()
        {
            foreach (var spawner in _spawners)
                spawner.Spawned += OnEnemySpawned;
        }

        private void OnEnemySpawned(IEntity enemy)
        {
            enemy.GetDieEvent().OnEvent += OnEnemyDied;
        }

        private void OnEnemyDied(IEntity enemy)
        {
            enemy.GetDieEvent().OnEvent -= OnEnemyDied;
            Killed?.Invoke(enemy);
        }

        public void OnFinish()
        {
            foreach (var spawner in _spawners)
            {
                foreach (var enemy in spawner.SpawnedEnemies)
                    enemy.GetDieEvent().OnEvent -= OnEnemyDied;
                
                spawner.Spawned -= OnEnemySpawned;
            }
        }
    }
}