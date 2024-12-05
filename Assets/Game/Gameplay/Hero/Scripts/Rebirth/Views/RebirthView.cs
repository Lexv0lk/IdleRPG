using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Gameplay.Hero
{
    public class RebirthView : MonoBehaviour
    {
        [SerializeField] private Button _rebirthButton;

        public event Action RebirthRequested;
        
        private void OnEnable()
        {
            _rebirthButton.onClick.AddListener(OnRebirthButtonClicked);
        }

        private void OnDisable()
        {
            _rebirthButton.onClick.RemoveListener(OnRebirthButtonClicked);
        }
        
        private void OnRebirthButtonClicked()
        {
            RebirthRequested?.Invoke();
        }
    }
}