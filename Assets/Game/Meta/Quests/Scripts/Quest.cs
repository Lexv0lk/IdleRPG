using System;
using System.Collections.Generic;
using Game.Meta.Rewards;

namespace Game.Meta.Quests
{
    public abstract class Quest
    {
        private readonly QuestConfig _config;

        public string Id => _config.Id;
        public QuestMetadata Metadata => _config.Metadata;
        public IReadOnlyCollection<IReward> Rewards => _config.Rewards;
        
        public QuestState State { get; private set; }
        
        public abstract float NormalizedProgress { get; }
        public abstract string TextProgress { get; }
        
        public event Action<Quest> Started;
        public abstract event Action<Quest> ProgressChanged;
        public event Action<Quest> Completed;

        public Quest(QuestConfig config)
        {
            _config = config;
            State = QuestState.NOT_STARTED;
        }

        public void Start()
        {
            if (State != QuestState.NOT_STARTED)
                throw new Exception("Mission already Started");

            State = QuestState.STARTED;
            Started?.Invoke(this);

            if (NormalizedProgress >= 1)
            {
                Complete();
                return;
            }
            
            OnStart();
        }

        public void Stop()
        {
            if (State != QuestState.STARTED)
                return;

            State = QuestState.NOT_STARTED;
            OnStop();
        }

        protected void TryComplete()
        {
            if (NormalizedProgress >= 1)
                Complete();
        }

        private void Complete()
        {
            if (State != QuestState.STARTED)
                throw new Exception("Mission is not started");

            State = QuestState.COMPLETED;
            OnStop();
            Completed?.Invoke(this);
        }
        
        #region Callbacks

        protected abstract void OnStart();

        protected abstract void OnStop();

        #endregion
    }
}