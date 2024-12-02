using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace Game.Gameplay.Resource
{
    public class ResourceView : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _count;

        private ResourceViewPresenter _presenter;
        
        public void Initialize(ResourceViewPresenter presenter)
        {
            _presenter = presenter;
            _icon.sprite = _presenter.ResourceIcon;

            _presenter.ResourceCount
                .StartWith(_presenter.ResourceCount.Value)
                .Subscribe(UpdateCount)
                .AddTo(this);
        }

        private void UpdateCount(string newCount)
        {
            _count.text = newCount;
        }
    }
}