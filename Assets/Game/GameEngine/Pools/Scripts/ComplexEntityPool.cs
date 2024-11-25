using System.Collections.Generic;
using System.Linq;
using Atomic.Entities;
using Game.Gameplay.GameStates;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Game.GameEngine.Pools
{
    public class ComplexEntityPool : SerializedMonoBehaviour, IGameInitializeListener
    {
        private readonly Dictionary<SceneEntity, EntityPool> _pools = new();
        
        [OdinSerialize] private Dictionary<SceneEntity, int> _prefabs = new();
        
        public void OnInitialize()
        {
            foreach (var (prefab, count) in _prefabs)
            {
                GameObject poolGameObject = new GameObject();
                poolGameObject.transform.parent = transform;
                poolGameObject.name = $"{prefab.name} Pool";
                
                EntityPool pool = poolGameObject.AddComponent<EntityPool>();
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