using Atomic.Entities;
using Game.UI;
using UnityEngine;
using Zenject;

namespace Game.GameEngine.Triggers
{
    public class UIOpenTrigger : BaseTrigger
    {
        [SerializeField] private RectTransform _uiElement;

        private UIOpenCloseController _openCloseController;
        
        [Inject]
        private void Construct(UIOpenCloseController openCloseController)
        {
            _openCloseController = openCloseController;
        }
        
        protected override void OnEntered(IEntity entity)
        {
            _openCloseController.Open(_uiElement.gameObject);
        }
    }
}