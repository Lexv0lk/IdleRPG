using System;
using System.Collections.Generic;
using Game.Configs;
using Game.GameEngine.Resource;
using Game.Meta.Rewards;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.Quests
{
    [Serializable]
    public class QuestRewardsDisplayer : MonoBehaviour, IRewardVisitor
    {
        private readonly HashSet<QuestRewardView> _currentViews = new();

        [SerializeField] private Transform _rewardsRoot;
        [SerializeField] private QuestRewardView _rewardViewPrefab;

        private ResourcesCatalog _resourcesCatalog;
        
        [Inject]
        private void Construct(ConfigService configService)
        {
            _resourcesCatalog = configService.GetConfig<ResourcesCatalog>();
        }
        
        public void Display(IEnumerable<IReward> rewards)
        {
            ClearCurrentViews();
            
            foreach (var reward in rewards)
                reward.Accept(this);
        }

        private void ClearCurrentViews()
        {
            foreach (var view in _currentViews)
                Destroy(view.gameObject);
            
            _currentViews.Clear();
        }
        
        public void Visit(ResourceReward reward)
        {
            foreach (var (resource, amount) in reward.Resources)
            {
                QuestRewardView rewardView = Instantiate(_rewardViewPrefab, _rewardsRoot);
                rewardView.Initialize(new ResourceRewardViewPresenter(_resourcesCatalog.GetConfig(resource), amount));
                _currentViews.Add(rewardView);
            }
        }
    }
}