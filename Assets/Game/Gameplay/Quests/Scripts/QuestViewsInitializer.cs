using Game.Gameplay.GameStates;
using Game.Meta.Quests;

namespace Game.Gameplay.Quests
{
    public class QuestViewsInitializer : IGameInitializeListener
    {
        private readonly QuestViewsService _viewsService;
        private readonly QuestsManager _questsManager;

        public QuestViewsInitializer(QuestViewsService viewsService, QuestsManager questsManager)
        {
            _viewsService = viewsService;
            _questsManager = questsManager;
        }
            
        public void OnInitialize()
        {
            _viewsService.CatalogView.Initialize(new QuestCatalogViewPresenter(_questsManager));
        }
    }
}