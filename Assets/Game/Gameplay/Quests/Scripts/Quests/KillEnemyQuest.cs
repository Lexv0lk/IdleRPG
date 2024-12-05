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

        public KillEnemyQuest(KillEnemyQuestConfig config) : base(config)
        {
            _config = config;
        }

        [Inject]
        private void Construct(EnemyKillObserver killObserver)
        {
            _killObserver = killObserver;
        }
        
        public int CurrentKills { get; private set; }

        public override float NormalizedProgress => (float)CurrentKills / _config.TargetKills;
        public override string TextProgress => $"{CurrentKills}/{_config.TargetKills}";
        public EnemyData TargetData => _config.TargetData;
        
        public override event Action<Quest> ProgressChanged;
        
        protected override void OnStart()
        {
            CurrentKills = 0;
            _killObserver.Killed += OnEnemyKilled;
        }

        public void Setup(int kills)
        {
            CurrentKills = kills;
            ProgressChanged?.Invoke(this);
            TryComplete();
        }

        private void OnEnemyKilled(IEntity enemy)
        {
            if (enemy.GetEnemyData().Id == _config.TargetData.Id)
            {
                CurrentKills++;
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