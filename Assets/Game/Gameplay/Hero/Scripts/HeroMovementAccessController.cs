using Atomic.Elements;
using Atomic.Entities;
using Game.Gameplay.GameStates;
using Game.UI;

namespace Game.Gameplay.Hero
{
    public class HeroMovementAccessController : IGameStartListener
    {
        private readonly HeroService _heroService;
        private readonly UIOpenCloseController _uiOpenCloseController;

        private IVariable<bool> _canMove;
        private bool _previousCanMoveValue;

        public HeroMovementAccessController(HeroService heroService, UIOpenCloseController uiOpenCloseController)
        {
            _heroService = heroService;
            _uiOpenCloseController = uiOpenCloseController;
            
            _uiOpenCloseController.FirstElementOpened += OnUIOpened;
            _uiOpenCloseController.AllElementsClosed += OnUIClosed;
        }

        private void OnUIClosed()
        {
            _canMove.Value = _previousCanMoveValue;
        }

        private void OnUIOpened()
        {
            _previousCanMoveValue = _canMove.Value;
            _canMove.Value = false;
        }

        public void OnStart()
        {
            _canMove = _heroService.Hero.GetCanMove();
        }
    }
}