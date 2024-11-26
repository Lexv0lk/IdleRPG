using System.Collections.Generic;
using System.Linq;
using Atomic.Entities;
using Game.Gameplay.GameStates;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;
using Zenject;

namespace Game.GameEngine.Pools
{
    public class ComplexEntityPool : SerializedMonoBehaviour, IGameInitializeListener
    {
        private readonly Dictionary<SceneEntity, EntityPool> _pools = new();
        
        [OdinSerialize] private Dictionary<SceneEntity, int> _prefabs = new();

        private DiContainer _diContainer;
        
        [Inject]
        private void Construct(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }
        
        public void OnInitialize()
        {
            foreach (var (prefab, count) in _prefabs)
            {
                GameObject poolGameObject = new GameObject();
                poolGameObject.transform.parent = transform;
                poolGameObject.name = $"{prefab.name} Pool";
                
                EntityPool pool = _diContainer.InstantiateComponent<EntityPool>(poolGameObject);
                pool.Initialize(prefab, count);
                _pools[prefab] = pool;
            }
        }

        public SceneEntity GetRandom()
        {
            SceneEntity prefabKey = _prefabs.Keys.ElementAt(Random.Range(0, _prefabs.Keys.Count));
            return _pools[prefabKey].Get();
        }

        public void Release(SceneEntity entity)
        {
            foreach (var pool in _pools.Values)
                pool.Release(entity);
        }
    }
}