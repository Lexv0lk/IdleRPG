using System.Linq;
using Game.Configs;
using Game.GameEngine.Resource;
using Game.Gameplay.GameStates;

namespace Game.Gameplay.Resource
{
    public class ResourcesManager : IGameInitializeListener
    {
        private readonly ResourcesStorage _storage;
        private readonly ResourceViewsService _uiService;
        private readonly ResourcesCatalog _resourcesCatalog;

        public ResourcesManager(ResourcesStorage storage, ConfigService configService,
            ResourceViewsService uiService)
        {
            _storage = storage;
            _uiService = uiService;
            
            _resourcesCatalog = configService.GetConfig<ResourcesCatalog>();
        }
        
        public void OnInitialize()
        {
            foreach (var (resourceConfig, amount) in _resourcesCatalog.InitialResources)
                _storage.Add(resourceConfig.Type, amount);
            
            _uiService.MoneyView
                .Initialize(new ResourceViewPresenter(_resourcesCatalog.GetConfig(ResourceType.MONEY), _storage));
        }
    }
}