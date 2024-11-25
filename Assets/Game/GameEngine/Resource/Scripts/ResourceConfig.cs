using UnityEngine;

namespace Game.GameEngine.Resource
{
    [CreateAssetMenu(fileName = "Resource Config", menuName = "Configs/Resource")]
    public class ResourceConfig : ScriptableObject
    {
        [SerializeField] private ResourceType _resourceType;
        [SerializeField] private Sprite _icon;

        public ResourceType Type => _resourceType;
        public Sprite Icon => _icon;
    }
}