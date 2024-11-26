using System.Collections.Generic;
using System.Linq;
using Atomic.Entities;
using UnityEngine;
using Zenject;

namespace Game.GameEngine.Pools
{
    public class EntityPool : MonoBehaviour
    {
        private readonly HashSet<SceneEntity> _availablePrefabs = new();
        
        [SerializeField] private SceneEntity _prefab;
        [SerializeField] private int _count;
        [SerializeField] private bool _initializeOnAwake;

        private DiContainer _container;

        [Inject]
        private void Construct(DiContainer container)
        {
            _container = container;
        }
        
        private void Awake()
        {
            if (_initializeOnAwake)
                Initialize();
        }

        public void Initialize(SceneEntity prefab, int count)
        {
            _prefab = prefab;
            _count = count;
            Initialize();
        }

        public void Initialize()
        {
            for (int i = 0; i < _count; i++)
            {
                var entity = _container.InstantiatePrefabForComponent<SceneEntity>(_prefab, transform);
                entity.gameObject.SetActive(false);
                _availablePrefabs.Add(entity);
            }
        }

        public SceneEntity Get()
        {
            SceneEntity entity;
    
            if (_availablePrefabs.Count > 0)
            {
                entity = _availablePrefabs.First();
                //entity.gameObject.SetActive(true);

                _availablePrefabs.Remove(entity);
            }
            else
            {
                entity = _container.InstantiatePrefabForComponent<SceneEntity>(_prefab, transform);
                entity.gameObject.SetActive(false);
            }

            entity.Install();
            return entity;
        }

        public void Release(SceneEntity entity)
        {
            if (_availablePrefabs.Add(entity))
            {
                entity.transform.SetParent(transform, false);
                entity.gameObject.SetActive(false);
                entity.Reset();
            }
        }
    }
}