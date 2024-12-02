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
        [SerializeField] private string _enemyId;
        [PropertySpace, SerializeField] private IReward[] _loot;
        
        public void Install(IEntity entity)
        {
            entity.AddEnemyId(_enemyId);
            entity.AddLoot(_loot);
        }
    }
}