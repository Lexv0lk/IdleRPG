using UnityEngine;
using Zenject;

namespace Game.Gameplay.GameStates
{
    public class GameStateController : MonoBehaviour
    {
        private GameStateModel _gameStateModel;

        private readonly IGameStateHandler _initializeHandler = new GameInitializeHandler();
        private readonly IGameStateHandler _startHandler = new GameStartHandler();
        private readonly IGameStateHandler _pauseHandler = new GamePauseHandler();
        private readonly IGameStateHandler _resumeHandler = new GameResumeHandler();
        private readonly IGameStateHandler _finishHandler = new GameFinishHandler();
        
        private readonly IGameUpdateHandler _updateHandler = new GameSimpleUpdateHandler();
        private readonly IGameUpdateHandler _fixedUpdateHandler = new GameFixedUpdateHandler();
        
        [Inject]
        private void Construct(GameStateModel gameStateModel)
        {
            _gameStateModel = gameStateModel;
        }
        
        private void Awake()
        {
            _initializeHandler.Handle(_gameStateModel);
        }

        private void Start()
        {
            _startHandler.Handle(_gameStateModel);
        }

        private void Update()
        {
            if (_gameStateModel.CurrentState == GameState.PLAYING)
            {
                float deltaTime = Time.deltaTime;
                _updateHandler.Handle(deltaTime);
            }
        }

        private void FixedUpdate()
        {
            if (_gameStateModel.CurrentState == GameState.PLAYING)
            {
                float deltaTime = Time.fixedDeltaTime;
                _fixedUpdateHandler.Handle(deltaTime);
            }
        }

        public void Pause()
        {
            _pauseHandler.Handle(_gameStateModel);
        }

        public void Resume()
        {
            _resumeHandler.Handle(_gameStateModel);
        }

        private void OnDestroy()
        {
            _finishHandler.Handle(_gameStateModel);
        }

        #region Registrations

        public void Register(IGameStateListener gameStateListener)
        {
            _initializeHandler.Register(gameStateListener);
            _startHandler.Register(gameStateListener);
            _pauseHandler.Register(gameStateListener);
            _resumeHandler.Register(gameStateListener);
            _finishHandler.Register(gameStateListener);
        }
        
        public void Register(IGameUpdateListener gameUpdateListener)
        {
            _updateHandler.Register(gameUpdateListener);
            _fixedUpdateHandler.Register(gameUpdateListener);
        }
        
        public void Remove(IGameStateListener gameStateListener)
        {
            _initializeHandler.Remove(gameStateListener);
            _startHandler.Remove(gameStateListener);
            _pauseHandler.Remove(gameStateListener);
            _resumeHandler.Remove(gameStateListener);
            _finishHandler.Remove(gameStateListener);
        }
        
        public void Remove(IGameUpdateListener gameUpdateListener)
        {
            _updateHandler.Remove(gameUpdateListener);
            _fixedUpdateHandler.Remove(gameUpdateListener);
        }

        #endregion
    }
}