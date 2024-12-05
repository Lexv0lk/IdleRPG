using System.Collections.Generic;
using System.Linq;
using Game.Configs;
using Game.GameEngine.DI;
using Game.GameEngine.Resource;
using Game.Gameplay.GameStates;

namespace Game.Gameplay.Resource
{
    public class ResourcesManager : IGameInitializeListener, IGameService
    {
        private readonly ResourcesStorage _storage;
        private readonly ResourceViewsService _uiService;
        private readonly ResourcesCatalog _resourcesCatalog;

        public ResourcesCatalog ResourcesCatalog => _resourcesCatalog;

        public ResourcesManager(ResourcesStorage storage, ConfigService configService,
            ResourceViewsService uiService)
        {
            _storage = storage;
            _uiService = uiService;
            
            _resourcesCatalog = configService.GetConfig<ResourcesCatalog>();
        }
        
        public void OnInitialize()
        {
            _uiService.MoneyView
                .Initialize(new ResourceViewPresenter(_resourcesCatalog.GetConfig(ResourceType.MONEY), _storage));
        }

        public void Setup(Dictionary<ResourceType, int> resources)
        {
            foreach (var (resourceType, amount) in resources)
                _storage.Add(resourceType, amount);
        }

        public IReadOnlyDictionary<ResourceType, int> GetCurrentResources()
        {
            return _storage.Resources;
        }
    }
}