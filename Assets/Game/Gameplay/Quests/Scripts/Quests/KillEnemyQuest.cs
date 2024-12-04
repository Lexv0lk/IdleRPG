using System;
using System.Linq;
using Atomic.Entities;
using Game.Gameplay.Enemy;
using Game.Meta.Quests;
using Zenject;

namespace Game.Gameplay.Quests
{
    public class KillEnemyQuest : Quest
    {
        private readonly KillEnemyQuestConfig _config;

        private EnemyKillObserver _killObserver;
        private int _currentKills;

        public KillEnemyQuest(KillEnemyQuestConfig config) : base(config)
        {
            _config = config;
        }

        [Inject]
        private void Construct(EnemyKillObserver killObserver)
        {
            _killObserver = killObserver;
        }

        public override float NormalizedProgress => (float)_currentKills / _config.TargetKills;
        public override string TextProgress => $"{_currentKills}/{_config.TargetKills}";
        public EnemyData TargetData => _config.TargetData;
        
        public override event Action<Quest> ProgressChanged;
        
        protected override void OnStart()
        {
            _currentKills = 0;
            _killObserver.Killed += OnEnemyKilled;
        }

        private void OnEnemyKilled(IEntity enemy)
        {
            if (enemy.GetEnemyData().Id == _config.TargetData.Id)
            {
                _currentKills++;
                ProgressChanged?.Invoke(this);
                TryComplete();
            }
        }

        protected override void OnStop()
        {
            _killObserver.Killed -= OnEnemyKilled;
        }
    }
}