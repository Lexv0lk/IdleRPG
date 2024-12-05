using Game.App.Loading;
using SaveSystem;
using SaveSystem.DataSaving;
using UnityEngine;
using Zenject;

namespace GameEngine.DI
{
    public class BootstrapInstaller : MonoInstaller
    {
        [SerializeField] private GameLoadingPipeline _loadingPipeline;
        
        public override void InstallBindings()
        {
            Container.BindInstance(_loadingPipeline).AsSingle();

            Container.Bind<IDataSaver>().To<PlayerPrefsSaver>().AsSingle();
            Container.Bind<GameRepository>().AsSingle();
            
            Container.Bind<GameLoader>().AsSingle();
        }
    }
}