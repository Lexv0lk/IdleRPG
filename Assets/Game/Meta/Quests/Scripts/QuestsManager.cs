using System;
using Game.Configs;
using Game.Meta.Rewards;
using UniRx;

namespace Game.Meta.Quests
{
    public class QuestsManager
    {
        private readonly QuestIssuingConfig _issuingConfig;
        private readonly QuestSupplier _questSupplier;
        private readonly DefaultRewardGiveController _rewardGiveController;
        private readonly ReactiveCollection<Quest> _activeQuests = new();

        public IReadOnlyReactiveCollection<Quest> ActiveQuests => _activeQuests;
        
        public QuestsManager(ConfigService configService, QuestSupplier questSupplier,
            DefaultRewardGiveController rewardGiveController)
        {
            _questSupplier = questSupplier;
            _rewardGiveController = rewardGiveController;
            _issuingConfig = configService.GetConfig<QuestIssuingConfig>();

            for (int i = 0; i < _issuingConfig.QuestAmountToDisplay; i++)
            {
                var quest = _questSupplier.GetNext();
                quest.Start();
                _activeQuests.Add(quest);
            }
        }
        
        public bool CanClaimQuest(Quest quest)
        {
            return quest.State == QuestState.COMPLETED && _activeQuests.Contains(quest);
        }

        public void ClaimQuest(Quest quest)
        {
            if (quest.State != QuestState.COMPLETED)
                throw new Exception($"Quest {quest.Id} is not completed");

            if (_activeQuests.Contains(quest) == false)
                throw new Exception($"Quest {quest.Id} is not in active quest list");

            foreach (var reward in quest.Rewards)
                reward.Accept(_rewardGiveController);

            Quest nextQuest = _questSupplier.GetNext();

            if (nextQuest != null)
            {
                int questIndex = _activeQuests.IndexOf(quest);
                _activeQuests[questIndex] = nextQuest;
                nextQuest.Start();
            }
            else
            {
                _activeQuests.Remove(quest);
            }
        }
    }
}