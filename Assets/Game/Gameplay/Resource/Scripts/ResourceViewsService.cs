using UnityEngine;

namespace Game.Gameplay.Resource
{
    public class ResourceViewsService : MonoBehaviour
    {
        [SerializeField] private ResourceView _moneyView;

        public ResourceView MoneyView => _moneyView;
    }
}