using System;
using Atomic.Entities;
using Game.Meta.Rewards;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Enemy
{
    [Serializable]
    public class EnemyCoreInstaller : IEntityInstaller
    {
        [SerializeField] private EnemyData _data;
        
        public void Install(IEntity entity)
        {
            entity.AddEnemyData(_data);
        }
    }
}