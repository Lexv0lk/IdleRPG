using System;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay.Enemy
{
    [Serializable]
    public class EnemyInitializer
    {
        private IEntityWorld _entityWorld;
        
        public void Construct(IEntityWorld entityWorld)
        {
            _entityWorld = entityWorld;
        }
        
        public void Initialize(SceneEntity enemy, Transform[] areaPoints)
        {
            enemy.SetWaypoints(areaPoints);
            _entityWorld.AddEntity(enemy);
            
            enemy.gameObject.SetActive(true);
            enemy.Init();
            enemy.Enable();
        }
    }
}