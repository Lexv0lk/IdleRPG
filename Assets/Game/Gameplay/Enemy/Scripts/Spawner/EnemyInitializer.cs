using System;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay.Enemy
{
    [Serializable]
    public class EnemyInitializer
    {
        public void Initialize(SceneEntity enemy, Transform[] areaPoints)
        {
            enemy.SetWaypoints(areaPoints);
        }
    }
}