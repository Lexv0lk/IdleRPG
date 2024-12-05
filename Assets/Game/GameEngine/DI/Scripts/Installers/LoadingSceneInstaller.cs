using Game.App.Loading;
using Game.App.Loading.Views;
using UnityEngine;
using Zenject;

namespace GameEngine.DI
{
    public class LoadingSceneInstaller : MonoInstaller
    {
        [SerializeField] private GameLoadingView _gameLoadingView;

        public override void InstallBindings()
        {
            Container.BindInstance(_gameLoadingView).AsSingle();
            Container.BindInterfacesAndSelfTo<AppBootstrap>().AsSingle().NonLazy();
        }
    }
}