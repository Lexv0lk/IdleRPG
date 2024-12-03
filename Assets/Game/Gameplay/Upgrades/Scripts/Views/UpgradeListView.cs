using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Gameplay.Upgrades
{
    public class UpgradeListView : MonoBehaviour
    {
        private readonly Dictionary<UpgradeViewPresenter, UpgradeView> _upgradeViews = new();
        
        [SerializeField] private UpgradeView _upgradeViewPrefab;
        [SerializeField] private Transform _upgradesRoot;
        [SerializeField] private Button _closeButton;

        private UpgradeListViewPresenter _presenter;
        
        public void Initialize(UpgradeListViewPresenter presenter)
        {
            _presenter = presenter;
            ClearCurrentUpgradeViews();

            foreach (var upgradePresenter in _presenter.UpgradePresenters)
            {
                UpgradeView view = Instantiate(_upgradeViewPrefab, _upgradesRoot);
                view.Initialize(upgradePresenter);
                _upgradeViews.Add(upgradePresenter, view);
            }
        }

        private void OnEnable()
        {
            _closeButton.onClick.AddListener(Close);
        }

        private void OnDisable()
        {
            _closeButton.onClick.RemoveListener(Close);
        }

        private void Close()
        {
            gameObject.SetActive(false);
        }

        private void ClearCurrentUpgradeViews()
        {
            foreach (var (presenter, view) in _upgradeViews)
                Destroy(view.gameObject);
            
            _upgradeViews.Clear();
        }
    }
}