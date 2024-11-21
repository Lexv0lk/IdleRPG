using Atomic.Elements;
using Atomic.Entities;
using Game.GameEngine.LocationServices;
using Game.Gameplay.GameStates;
using Modules.Input;
using UnityEngine;

namespace Game.Gameplay.Hero
{
    public class HeroMovementController : IGameStartListener, IGameFinishListener
    {
        private readonly HeroService _heroService;
        private readonly SwipeInput _swipeInput;

        private IReactiveVariable<Vector3> _moveDirection;

        public HeroMovementController(HeroService heroService, SwipeInput swipeInput)
        {
            _heroService = heroService;
            _swipeInput = swipeInput;
        }

        public void OnStart()
        {
            _moveDirection = _heroService.Hero.GetMoveDirection();
            _swipeInput.DirectionMoved += OnDirectionChanged;
        }

        public void OnFinish()
        {
            _swipeInput.DirectionMoved -= OnDirectionChanged;
        }

        private void OnDirectionChanged(Vector2 dir)
        {
            _moveDirection.Value = new Vector3(dir.x, 0, dir.y);
        }
    }
}