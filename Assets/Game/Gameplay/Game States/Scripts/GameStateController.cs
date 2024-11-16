using UnityEngine;
using Zenject;

namespace Game.Gameplay.GameStates
{
    public class GameStateController : MonoBehaviour
    {
        private GameStateModel _gameStateModel;

        private IGameStateHandler _initializeHandler;
        private IGameStateHandler _startHandler;
        private IGameStateHandler _pauseHandler;
        private IGameStateHandler _resumeHandler;
        private IGameStateHandler _finishHandler;
        
        private IGameUpdateHandler _updateHandler;
        private IGameUpdateHandler _fixedUpdateHandler;
        
        [Inject]
        private void Construct(GameStateModel gameStateModel)
        {
            _gameStateModel = gameStateModel;

            _initializeHandler = new GameInitializeHandler();
            _startHandler = new GameStartHandler();
            _pauseHandler = new GamePauseHandler();
            _resumeHandler = new GameResumeHandler();
            _finishHandler = new GameFinishHandler();

            _updateHandler = new GameSimpleUpdateHandler();
            _fixedUpdateHandler = new GameFixedUpdateHandler();
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
    }
}