using System;
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

        public override float NormalizedProgress { get; }
        public override string TextProgress { get; }
        
        public override event Action<Quest> ProgressChanged;
        
        protected override void OnStart()
        {
            _currentKills = 0;
            _killObserver.Killed += OnEnemyKilled;
        }

        private void OnEnemyKilled(IEntity enemy)
        {
            throw new NotImplementedException();
        }

        protected override void OnStop()
        {
            
        }
    }
}