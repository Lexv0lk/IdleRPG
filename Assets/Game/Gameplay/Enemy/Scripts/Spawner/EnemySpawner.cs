using System;
using System.Collections.Generic;
using Atomic.Entities;
using Game.GameEngine.LocationServices;
using Game.GameEngine.Pools;
using Game.Gameplay.GameStates;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.Enemy
{
    public class EnemySpawner : MonoBehaviour, IGameSimpleUpdateListener, IGameStartListener, IGameFinishListener
    {
        private readonly HashSet<SceneEntity> _currentEntities = new();
        
        [SerializeField] private SceneEntity[] _possibleEnemies;
        [SerializeField] private AreaPointDecider _areaPointDecider;
        [SerializeField] private EnemyInitializer _initializer;
        [SerializeField] private ComplexEntityPool _entityPool;

        [Header("Spawn Settings")] 
        [SerializeField] private int _enemiesCount;
        [SerializeField] private float _spawnDelay;

        private float _timeForNextEnemy;
        private HeroService _heroService;
        private IEntityWorld _entityWorld;

        public IReadOnlyCollection<SceneEntity> SpawnedEnemies => _currentEntities;

        public event Action<IEntity> Spawned; 

        [Inject]
        private void Construct(HeroService heroService, IEntityWorld entityWorld)
        {
            _heroService = heroService;
            _entityWorld = entityWorld;
            
            _initializer.Construct(_entityWorld);
        }
        
        [Button]
        public void OnStart()
        {
            for (int i = 0; i < _enemiesCount; i++)
                SpawnNewEnemy(_areaPointDecider.AllPoints[i % _areaPointDecider.AllPoints.Length]);
        }
        
        public void OnUpdate(float deltaTime)
        {
            if (_currentEntities.Count >= _enemiesCount)
                return;

            if (_timeForNextEnemy > 0)
            {
                _timeForNextEnemy -= deltaTime;
                return;
            }

            SpawnNewEnemy(_areaPointDecider.GetPoint(_currentEntities, _heroService.Hero));
            _timeForNextEnemy = _spawnDelay;
        }

        private void SpawnNewEnemy(Transform point)
        {
            SceneEntity entity = _entityPool.GetRandom();
            
            entity.transform.position = point.position;
            _initializer.Initialize(entity, _areaPointDecider.AllPoints);

            _currentEntities.Add(entity);
            entity.GetDieEvent().OnEvent += OnKilled;
            Spawned?.Invoke(entity);
        }

        private void OnKilled(IEntity enemy)
        {
            enemy.GetDieEvent().OnEvent -= OnKilled;
            _currentEntities.Remove(enemy.GetTransform().gameObject.GetComponent<SceneEntity>());
        }

        public void OnFinish()
        {
            foreach (var entity in _currentEntities)
                entity.GetDieEvent().OnEvent -= OnKilled;
        }
    }
}