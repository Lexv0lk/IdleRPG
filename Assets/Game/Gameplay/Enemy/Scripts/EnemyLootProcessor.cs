using System;
using Atomic.Entities;
using Game.GameEngine.Resource;
using Game.Gameplay.GameStates;
using Game.Meta.Rewards;

namespace Game.Gameplay.Enemy
{
    public class EnemyLootProcessor : IGameStartListener, IGameFinishListener, IRewardVisitor
    {
        private readonly EnemyKillObserver _killObserver;
        private readonly ResourcesStorage _resourcesStorage;

        public event Action<IReward> RewardProccessed; 

        public EnemyLootProcessor(EnemyKillObserver killObserver, ResourcesStorage resourcesStorage)
        {
            _killObserver = killObserver;
            _resourcesStorage = resourcesStorage;
        }
        
        public void OnStart()
        {
            _killObserver.Killed += OnKilled;
        }

        private void OnKilled(IEntity enemy)
        {
            if (enemy.TryGetLoot(out var rewards))
            {
                foreach (var reward in rewards)
                {
                    reward.Accept(this);
                    RewardProccessed?.Invoke(reward);
                }
            }
        }

        public void OnFinish()
        {
            _killObserver.Killed -= OnKilled;
        }

        public void Visit(ResourceReward reward)
        {
            foreach (var (res, amount) in reward.Resources)
                _resourcesStorage.Add(res, amount);
        }
    }
}