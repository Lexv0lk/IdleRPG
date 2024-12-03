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
        [SerializeField] private TMP_Text _description;
        [SerializeField] private TMP_Text _level;
        
        [Space]
        [SerializeField] private TMP_Text _price;
        [SerializeField] private Image _priceIcon;
        
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
            
            _presenter.Description
                .StartWith(_presenter.Description.Value)
                .SubscribeToTextTMP(_description)
                .AddTo(this);
            _presenter.Level
                .StartWith(_presenter.Level.Value)
                .SubscribeToTextTMP(_level)
                .AddTo(this);
            _presenter.Price
                .StartWith(_presenter.Price.Value)
                .SubscribeToTextTMP(_price)
                .AddTo(this);

            _presenter.ShowPrice
                .StartWith(_presenter.ShowPrice.Value)
                .Subscribe(OnShowPriceChanged)
                .AddTo(this);
        }

        private void OnShowPriceChanged(bool showPrice)
        {
            _price.gameObject.SetActive(showPrice);
            _priceIcon.gameObject.SetActive(showPrice);
        }
    }
}