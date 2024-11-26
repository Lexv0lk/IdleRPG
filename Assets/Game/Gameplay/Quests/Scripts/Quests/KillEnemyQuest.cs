using System;
using System.Linq;
using Atomic.Entities;
using Game.Gameplay.Combat;
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
        public override string TextProgress => $"";
        
        public override event Action<Quest> ProgressChanged;
        
        protected override void OnStart()
        {
            _currentKills = 0;
            _killObserver.Killed += OnEnemyKilled;
        }

        private void OnEnemyKilled(IEntity enemy)
        {
            if (_config.PossibleEnemyIds.Contains(enemy.GetEnemyId()))
            {
                _currentKills++;
                TryComplete();
            }
        }

        protected override void OnStop()
        {
            _killObserver.Killed -= OnEnemyKilled;
            _currentKills = 0;
        }
    }
}