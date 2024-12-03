using Game.GameEngine.Resource;
using UnityEngine;

namespace Game.Meta.Rewards
{
    public class ResourceRewardViewPresenter
    {
        public Sprite Icon { get; }
        public string Value { get; }

        public ResourceRewardViewPresenter(ResourceConfig resource, int count)
        {
            Icon = resource.Icon;
            Value = count.ToString();
        }
    }
}