using System.Collections.Generic;
using Game.GameEngine.DI;
using Game.Gameplay.GameStates;
using SaveSystem;
using UnityEngine;

namespace Game.App.SaveSystem
{
    public class SaveLoadingController : IGameInitializeListener, IGameFinishListener
    {
        private readonly GameRepository _gameRepository;
        private readonly GameContext _gameContext;
        private readonly List<ISaveLoader> _saveLoaders;

        public SaveLoadingController(GameRepository gameRepository, GameContext gameContext, List<ISaveLoader> saveLoaders)
        {
            _gameRepository = gameRepository;
            _gameContext = gameContext;
            _saveLoaders = saveLoaders;
        }
        
        public void OnInitialize()
        {
            Load();
        }

        public void OnFinish()
        {
            Save();
        }

        private void Load()
        {
            foreach (var saveLoader in _saveLoaders)
                saveLoader.LoadState(_gameRepository, _gameContext);
        }

        private void Save()
        {
            foreach (var saveLoader in _saveLoaders)
                saveLoader.SaveState(_gameRepository, _gameContext);
            
            _gameRepository.SaveState();
        }
    }
}