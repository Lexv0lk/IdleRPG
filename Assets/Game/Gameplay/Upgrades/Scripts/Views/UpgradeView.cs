using Modules.UniRxExtensions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace Game.Gameplay.Upgrades
{
    public class UpgradeView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _title;
        [SerializeField] private Image _icon;
        
        [Space]
        [SerializeField] private TMP_Text _currentStats;
        [SerializeField] private TMP_Text _nextImprovement;
        
        [Space]
        [SerializeField] private TMP_Text _price;
        [SerializeField] private Image _priceIcon;

        [Space] 
        [SerializeField] private GameObject _maxLevelBar;
        
        [Space]
        [SerializeField] private Button _upgradeButton;

        private UpgradeViewPresenter _presenter;
        
        public void Initialize(UpgradeViewPresenter presenter)
        {
            _presenter = presenter;

            _title.text = presenter.Title;
            _icon.sprite = presenter.Icon;
            _priceIcon.sprite = _presenter.PriceIcon;

            _presenter.LevelUpCommand.BindTo(_upgradeButton).AddTo(this);

            _presenter.CurrentStats
                .StartWith(_presenter.CurrentStats.Value)
                .SubscribeToTextTMP(_currentStats)
                .AddTo(this);
            _presenter.Price
                .StartWith(_presenter.CurrentStats.Value)
                .SubscribeToTextTMP(_price)
                .AddTo(this);            
            _presenter.NextImprovement
                .StartWith(_presenter.CurrentStats.Value)
                .SubscribeToTextTMP(_nextImprovement)
                .AddTo(this);
            
            _presenter.IsMaxLevel
                .StartWith(_presenter.IsMaxLevel.Value)
                .Subscribe(OnIsMaxLevelChanged)
                .AddTo(this);
        }

        private void OnIsMaxLevelChanged(bool isMaxLevel)
        {
            _maxLevelBar.SetActive(isMaxLevel);
            _nextImprovement.gameObject.SetActive(!isMaxLevel);
            _price.gameObject.SetActive(!isMaxLevel);
            _priceIcon.gameObject.SetActive(!isMaxLevel);
        }
    }
}