using System;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay.Enemy
{
    [Serializable]
    public class EnemyVisualInstaller : IEntityInstaller
    {
        [SerializeField] private NameView _nameView;
        
        public void Install(IEntity entity)
        {
            _nameView.Initialize(new NameViewPresenter(entity.GetEnemyData().Metadata.Name));
        }
    }
}