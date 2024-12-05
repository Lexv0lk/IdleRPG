using Game.App.SaveSystem;
using Game.App.SaveSystem.Resource;
using Game.GameEngine.DI;
using Zenject;

namespace GameEngine.DI
{
    public class SaveLoadSystemInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<UpgradesSaveLoader>().AsCached();
            Container.BindInterfacesAndSelfTo<QuestsSaveLoader>().AsCached();
            Container.BindInterfacesAndSelfTo<ResourcesSaveLoader>().AsCached();
            
            Container.Bind<GameContext>().AsSingle();
            Container.BindInterfacesAndSelfTo<SaveLoadingController>().AsSingle().NonLazy();
        }
    }
}