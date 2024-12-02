using System.Threading;
using Atomic.Elements;
using Atomic.Entities;
using Cysharp.Threading.Tasks;
using Game.Configs;
using UniRx;
using UnityEngine;

namespace Game.Gameplay.Character
{
    public class HealthViewPresenter : IHealthViewPresenter
    {
        private readonly HealthViewConfig _healthViewConfig;
        private readonly IReactiveValue<int> _currentHealth;
        private readonly IReactiveValue<int> _maxHealth;

        private bool _isDelayedDeactivating;
        private CancellationTokenSource _cts;
        
        public StringReactiveProperty Health { get; }
        public FloatReactiveProperty HealthPart { get; }
        public BoolReactiveProperty CanShowHealth { get; }

        public HealthViewPresenter(IEntity entity, ConfigService configService)
        {
            _healthViewConfig = configService.GetConfig<HealthViewConfig>();

            Health = new StringReactiveProperty();
            HealthPart = new FloatReactiveProperty();
            CanShowHealth = new BoolReactiveProperty();

            _currentHealth = entity.GetHealth();
            _maxHealth = entity.GetMaxHealth();

            _currentHealth.Subscribe(OnHealthChanged);
            _maxHealth.Subscribe(OnHealthChanged);
        }

        private void OnHealthChanged(int _)
        {
            Health.Value = $"{_currentHealth.Value}/{_maxHealth.Value}";
            HealthPart.Value = (float)_currentHealth.Value / _maxHealth.Value;
            CanShowHealth.Value = HealthPart.Value > 0;

            if (_isDelayedDeactivating)
            {
                _cts.Cancel();
                _cts.Dispose();
            }
            
            if (Mathf.Approximately(HealthPart.Value, 1))
                DisableHealthViewDelayedAsync();
        }
        
        private async UniTask DisableHealthViewDelayedAsync()
        {
            _isDelayedDeactivating = true;
            _cts = new CancellationTokenSource();
            
            await UniTask.Delay((int)(_healthViewConfig.MaximalIdleItem * 1000), cancellationToken: _cts.Token);

            if (_cts.IsCancellationRequested == false)
            {
                CanShowHealth.Value = false;
                _isDelayedDeactivating = false;
                _cts.Dispose();
            }
        }
    }
}