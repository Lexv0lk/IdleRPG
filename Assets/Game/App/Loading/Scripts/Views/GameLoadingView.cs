using Modules.UniRxExtensions;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Game.App.Loading.Views
{
    public class GameLoadingView : MonoBehaviour
    {
        [SerializeField] private Image _progressSlider;
        [SerializeField] private TMP_Text _description;
        
        public void Initialize(GameLoadingViewPresenter presenter)
        {
            presenter.Progress
                .StartWith(presenter.Progress.Value)
                .Subscribe(OnProgressChanged)
                .AddTo(this);

            presenter.Description
                .StartWith(presenter.Description.Value)
                .SubscribeToTextTMP(_description)
                .AddTo(this);
        }

        private void OnProgressChanged(float val)
        {
            _progressSlider.fillAmount = val;
        }
    }
}