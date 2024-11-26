using System;
using System.Collections.Generic;
using Atomic.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Enemy
{
    [Serializable]
    public class EnemyCoreInstaller : IEntityInstaller
    {
        [SerializeField] private string _enemyId;
        
        public void Install(IEntity entity)
        {
            entity.AddEnemyId(_enemyId);
        }
    }
}