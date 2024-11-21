using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Gameplay.Character
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private Image _healthBar;
        [SerializeField] private TMP_Text _healthText;
        
        private IHealthViewPresenter _presenter;
        
        public void Initialize(IHealthViewPresenter presenter)
        {
            _presenter = presenter;
            
            _presenter.Health
                .StartWith(_presenter.Health.Value)
                .Subscribe(OnHealthTextChanged)
                .AddTo(this);

            _presenter.HealthPart
                .StartWith(_presenter.HealthPart.Value)
                .Subscribe(OnHealthPartChanged)
                .AddTo(this);

            _presenter.CanShowHealth
                .StartWith(_presenter.CanShowHealth.Value)
                .Subscribe(OnShowConditionChanged)
                .AddTo(this);
        }

        private void OnHealthTextChanged(string newValue)
        {
            _healthText.text = newValue;
        }
        
        private void OnHealthPartChanged(float newValue)
        {
            _healthBar.fillAmount = newValue;
        }

        private void OnShowConditionChanged(bool canShow)
        {
            gameObject.SetActive(canShow);
        }
    }
}