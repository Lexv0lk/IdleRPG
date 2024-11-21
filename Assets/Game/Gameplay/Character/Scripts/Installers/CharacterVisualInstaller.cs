using System;
using Atomic.Entities;
using Game.GameEngine.LocationServices;
using UnityEngine;

namespace Game.Gameplay.Character
{
    [Serializable]
    public class CharacterVisualInstaller : IEntityInstaller
    {
        [SerializeField] private HealthView _healthView;

        private ConfigService _configService;
        
        public void Construct(ConfigService configService)
        {
            _configService = configService;
        }
        
        public void Install(IEntity entity)
        {
            _healthView.Initialize(new HealthViewPresenter(entity, _configService));
        }
    }
}