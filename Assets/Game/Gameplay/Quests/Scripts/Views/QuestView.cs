using System;
using Modules.UniRxExtensions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace Game.Gameplay.Quests
{
    public class QuestView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _title;
        [SerializeField] private TMP_Text _description;
        [SerializeField] private Image _icon;

        [Space] 
        [SerializeField] private Slider _progressBar;
        [SerializeField] private TMP_Text _progressText;

        [Space]
        [SerializeField] private Button _claimButton;
        [SerializeField] private TMP_Text _claimText;

        [Space]
        [SerializeField] private QuestRewardsDisplayer _rewardsDisplayer;

        private QuestViewPresenter _presenter;
        private CompositeDisposable _compositeDisposable;

        public void Initialize(QuestViewPresenter presenter)
        {
            DisposeCurrentPresenter();
            _presenter = presenter;
            _compositeDisposable = new CompositeDisposable();
            
            _title.text = presenter.Title;
            _description.text = presenter.Description;
            _icon.sprite = presenter.Icon;
            
            _rewardsDisplayer.Display(presenter.Rewards);

            presenter.Progress
                .StartWith(presenter.Progress.Value)
                .Subscribe(OnQuestProgressChanged)
                .AddTo(_compositeDisposable);
            presenter.TextProgress
                .StartWith(presenter.TextProgress.Value)
                .SubscribeToTextTMP(_progressText)
                .AddTo(_compositeDisposable);
            presenter.ClaimText
                .StartWith(presenter.ClaimText.Value)
                .SubscribeToTextTMP(_claimText)
                .AddTo(_compositeDisposable);

            presenter.ClaimCommand.BindTo(_claimButton).AddTo(_compositeDisposable);
        }

        private void OnQuestProgressChanged(float newValue)
        {
            _progressBar.value = newValue;
        }

        private void DisposeCurrentPresenter()
        {
            if (_presenter != null)
            {
                _compositeDisposable.Dispose();
                _presenter = null;
            }
        }

        private void OnDestroy()
        {
            DisposeCurrentPresenter();
        }
    }
}