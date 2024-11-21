using Game.GameEngine.LocationServices;
using Game.Gameplay.Hero;
using Zenject;

namespace GameEngine.DI
{
    public class HeroInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<HeroService>().FromComponentInHierarchy().AsSingle();

            Container.BindInterfacesAndSelfTo<HeroMovementController>().AsSingle().NonLazy();
        }
    }
}