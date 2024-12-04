using UnityEngine;

namespace Game.Gameplay.Quests
{
    public class QuestViewsService : MonoBehaviour
    {
        [SerializeField] private QuestCatalogView _catalogView;

        public QuestCatalogView CatalogView => _catalogView;
    }
}