using System;
using System.Collections.Generic;
using Game.Meta.Quests;
using Game.Meta.Rewards;
using UniRx;
using UnityEngine;

namespace Game.Gameplay.Quests
{
    public class QuestViewPresenter
    {
        private readonly Quest _quest;
        private readonly QuestsManager _questsManager;
        private readonly BoolReactiveProperty _canClaim;
        private readonly StringReactiveProperty _claimText;
        private readonly StringReactiveProperty _textProgress;
        private readonly FloatReactiveProperty _progress;
        private readonly CompositeDisposable _compositeDisposable;
        
        public string Title { get; }
        public Sprite Icon { get; }
        public string Description { get; }

        public IReadOnlyReactiveProperty<string> TextProgress => _textProgress;
        public IReadOnlyReactiveProperty<float> Progress => _progress;
        public IReadOnlyCollection<IReward> Rewards { get; }
        
        public ReactiveCommand ClaimCommand { get; }
        public IReadOnlyReactiveProperty<string> ClaimText => _claimText;
        
        public QuestViewPresenter(Quest quest, QuestsManager questsManager)
        {
            _quest = quest;
            _questsManager = questsManager;
            _compositeDisposable = new CompositeDisposable();

            Title = _quest.Metadata.Title;
            Icon = _quest.Metadata.Icon;
            Description = _quest.Metadata.Description;

            _textProgress = new StringReactiveProperty(_quest.TextProgress);
            _progress = new FloatReactiveProperty(_quest.NormalizedProgress);
            Rewards = _quest.Rewards;

            _canClaim = new BoolReactiveProperty(quest.State == QuestState.COMPLETED);
            ClaimCommand = new ReactiveCommand(_canClaim);
            _claimText = new StringReactiveProperty(GetCurrentClaimQuest());

            ClaimCommand.Subscribe(ClaimQuest).AddTo(_compositeDisposable);
            
            _quest.ProgressChanged += UpdateValues;
            _quest.Completed += UpdateValues;
        }
        
        private void ClaimQuest(Unit _)
        {
            _questsManager.ClaimQuest(_quest);
        }

        private void UpdateValues(Quest quest)
        {
            _progress.Value = quest.NormalizedProgress;
            _textProgress.Value = quest.TextProgress;
            _canClaim.Value = _questsManager.CanClaimQuest(_quest);
            _claimText.Value = GetCurrentClaimQuest();
        }

        private string GetCurrentClaimQuest()
        {
            return _canClaim.Value ? "Получить" : "В процессе";
        }
        
        ~QuestViewPresenter()
        {
            _quest.ProgressChanged -= UpdateValues;
            _quest.Completed -= UpdateValues;
            _compositeDisposable.Dispose();
        }
    }
}