using Atomic.Entities;
using Game.Gameplay.GameStates;
using Game.UI;

namespace Game.Gameplay.Hero
{
    public class RebirthController : IGameStartListener, IGameFinishListener
    {
        private readonly RebirthService _rebirthService;
        private readonly HeroService _heroService;
        private readonly UIOpenCloseController _uiOpenCloseController;

        public RebirthController(RebirthService rebirthService, HeroService heroService,
            UIOpenCloseController uiOpenCloseController)
        {
            _rebirthService = rebirthService;
            _heroService = heroService;
            _uiOpenCloseController = uiOpenCloseController;
        }
            
        public void OnStart()
        {
            _heroService.Hero.GetDieEvent().Subscribe(OnHeroDied);
            _rebirthService.RebirthView.RebirthRequested += OnRebirthRequested;
        }

        private void OnRebirthRequested()
        {
            var hero = _heroService.Hero;
            var navMeshAgent = hero.GetNavMeshAgent();
            
            navMeshAgent.enabled = false;
            hero.GetTransform().position = _rebirthService.RebirthLocation.position;
            navMeshAgent.enabled = true;

            hero.GetHealth().Value = hero.GetMaxHealth().Value;
            hero.GetIsDead().Value = false;
            
            _uiOpenCloseController.Close(_rebirthService.RebirthView.gameObject);
        }

        private void OnHeroDied(IEntity hero)
        {
            _uiOpenCloseController.Open(_rebirthService.RebirthView.gameObject);
        }

        public void OnFinish()
        {
            _heroService.Hero.GetDieEvent().Unsubscribe(OnHeroDied);
            _rebirthService.RebirthView.RebirthRequested -= OnRebirthRequested;
        }
    }
}